using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Reflection;


namespace BDZ
{
    public partial class Form1 : Form
    {
        #region FormInner
        // TODO: move all connection code to commandExecutor
        static OleDbConnection connection;
        static OleDbCommand command = new OleDbCommand();
        static CommandExecutor commandExecutor;

        private static IList<DBTableInfo> infoDB;
        private static List<DBQueryInfo> queries;
        private static List<DBProcedureInfo> procs;
        private static List<DBFunctionInfo> functions;

        // Conditions Controllers Set
        List<Control> conditionsSet = new List<Control>();

        // List Items Change When TableCheck
        private List<String> possibleInsertOrUpdateFields = new List<String>();
        private Label fieldLabel;
        private TextBox fieldTextBox;
        private string lastAdded = "";

        public void handleExit()
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                System.Environment.Exit(1);
            }
        }

        public Form1()
        {
            OpenFileDialog OPF = new OpenFileDialog();
            
            if (OPF.ShowDialog() != DialogResult.OK)
            {
                handleExit();
            }
            else
            {
                string fileName = OPF.FileName;
                if (!(new string[] { "accdb", "db", "mdb", "mdf" }.Contains(fileName.Split('.').Last())))
                {
                    Console.WriteLine("Unknown DB extension. Please, specify new path.");
                    handleExit();
                }
                else
                {
                    connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName);
                    commandExecutor = new CommandExecutor(connection, command);
                }
            }

            // Constructor => Init UI
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Establish a new connection on Form Load
            command.Connection = connection;

            // Get Info From Connection
            infoDB = getDBInfo();
            queries = getSQLQueriesInfo();
            // Assing Values
            procs = new List<DBProcedureInfo>();
            functions = new List<DBFunctionInfo>();
            // Fullfill this.procs & this.functions
            getDBProcAndFuncList();
            // Init UI
            fillComboBoxes(infoDB);
            disableOptionsOnRadioButtonClick(existingQueryGroupBox);
        }

        private void fillComboBoxes(IList<DBTableInfo> infoDB)
        {
            /* Pass fetched info to comboBoxes */

            // Query Type ComboBox
            categoryComboBox.Items.AddRange(
                new string[] { "SELECT", "UPDATE", "DELETE", "INSERT" }
            );

            // Tables ComboBox
            foreach (DBTableInfo tableInfo in infoDB)
            {
                tablesCheckedListBox.Items.Add(wrap(tableInfo.TableName));

                // For Each DBTableInfo Instance, Add Fields To Queries ComboBox
                // Uncomment To Add All Existing Fields On Init
                /*foreach (String tableInfoField in tableInfo.Fields)
                {
                    fieldsCheckedListBox.Items.Add(
                        String.Format("{0}.{1}", tableInfo.TableName, tableInfoField));
                }*/
            }

            // Existing Queries Combobox
            foreach (DBQueryInfo q in queries)
                queryComboBox.Items.Add(q.queryName);

            // Existing Procedures Combobox
            foreach (DBProcedureInfo p in procs)
                existingProcComboBox.Items.Add(p.procName);

            // Existing Functions Combobox
            foreach (DBFunctionInfo f in functions)
                existingFunctionComboBox.Items.Add(f.funcName);

            /* Conditions ComboBoxes */
            caseConditionsComboBox.Items.AddRange(
                new string[] { "WHERE", "CONNECT BY", "HAVING", "START WITH" }
            );
            operatorsConditionsComboBox.Items.AddRange(
                new string[] { "AND", "OR", "NOT", "IN", "ALL", "ANY", "EXISTS", "BETWEEN", "LIKE" }
            );
            comparatorConditionsComboBox.Items.AddRange(
                new string[] { "=", ">", "<", ">=", "<=" }
            );
            actionsConditionsComboBox.Items.AddRange(
                new string[] { "SELECT", "INSERT", "UPDATE", "DELETE" }
            );
            aggregateConditionsComboBox.Items.AddRange(
                new string[] { "AVG()", "COUNT()", "MAX()", "MIN()", "SUM()" }
            );
        }

        private List<Control> createUpdateAndInsertControllerSet()
        {
            /* Method Creates A Bunch Of Controls When Table Check 
             * And INSERT Or UPDATE Query Type Selected.
             */

            // Fetch Targeting Table Name. If More Than 1 Table => Throw Error
            if (commandExecutor.queryTables.Count != 1)
            {
                return new List<Control>();
            }

            // Value To Return
            List<Control> fieldsSet = new List<Control>();

            // Table Fields For Targeting Table Are Saved in possibleInsertOrUpdateFields
            // So Just Create Labels and Controls In A Loop
            for (int i = 0; i < possibleInsertOrUpdateFields.Count; i++)
            {
                fieldLabel = new Label();
                fieldLabel.Text = possibleInsertOrUpdateFields[i];
                fieldLabel.AutoSize = true;
                fieldLabel.Location = new Point(0, 0 + 40 * i);

                fieldsSet.Add(fieldLabel);

                fieldTextBox = new TextBox();
                fieldTextBox.Location = new Point(0, 16 + 40 * i);
                fieldTextBox.Width = 395;
                fieldsSet.Add(fieldTextBox);
            }

            return fieldsSet;
        }

        private void mainTabWindow_Selecting(object sender, TabControlCancelEventArgs e)
        {
            /* Tab Changed - Define On Which Tab We Are And Set tabChosenIndex option */
            commandExecutor.tabChosenIndex = (byte)mainTabWindow.SelectedIndex;
        }
        #endregion

        #region QueryExecutor_Ends
        private IList<DBTableInfo> getDBInfo()
        {
            /* Fetch Connection Schema Information And 
             * Return IList Of DBTableInfo Class Instances
             * Each Containing Info On Separate Table 
             */

            // Value to return
            IList<DBTableInfo> infoDB = new List<DBTableInfo>();

            // Connection To Get Tables List From BD Schema
            connection.Open();
            DataTable schemaInfo = connection.GetSchema("Tables", new string[] { null, null, null, "TABLE" });
            connection.Close();

            // New Connection For Each Table To Get Table Fields 
            foreach (DataRow table in schemaInfo.Rows)
            {
                connection.Open();
                // Execute Query (No Data Interesting)
                command.CommandText = String.Format(
                    "SELECT * FROM [{0}] WHERE 1 = 0",
                    table["TABLE_NAME"].ToString()
                );
                command.CommandType = CommandType.Text;
                OleDbDataReader reader = command.ExecuteReader();

                // Fetch Schema Info From reader Query
                DataTable tableInfo = reader.GetSchemaTable();

                // Init New DBTableInfo Class Instance
                DBTableInfo infoObject = new DBTableInfo();
                // Init New String List For Fields Names
                IList<String> infoFields = new List<String>();

                // Get Fields (ColumnNames)
                foreach (DataRow row in tableInfo.Rows)
                {
                    // Fill the String List With Fields Names
                    infoFields.Add(String.Format(row.Field<string>("ColumnName")));
                }

                // Assign DBTableInfo Instance Fields
                infoObject.TableName = table["TABLE_NAME"].ToString();
                infoObject.Fields = infoFields;
                connection.Close();
                // Add Generated And Fullfilled DBTableInfo Instance To List To Return
                infoDB.Add(infoObject);
            }
            return infoDB;
        }

        private List<DBQueryInfo> getSQLQueriesInfo()
        {
            /* Fetch Connection Schema Information And
             * Return IList Of DBTableInfo Class Instances
             * Each Containing Info On Separate Table 
             */

            // Value to return
            List<DBQueryInfo> viewsDB = new List<DBQueryInfo>();

            // Connection To Get Views List From BD Schema
            connection.Open();
            DataTable schemaInfo = connection.GetSchema("Views");
            connection.Close();

            // New Connection For Each View 
            foreach (DataRow view in schemaInfo.Rows)
            {
                DBQueryInfo queryInfoObj = new DBQueryInfo();
                queryInfoObj.queryName = view["TABLE_NAME"].ToString();
                queryInfoObj.queryString = view["VIEW_DEFINITION"].ToString();
                string description = String.Format(
                    @"Catalog: {0};Schema: {1};Check option: {2};Updatable: {3};Description: {4};Created: {5};Modified: {6}",
                    view["TABLE_CATALOG"], view["TABLE_SCHEMA"], view["CHECK_OPTION"], view["IS_UPDATABLE"], view["DESCRIPTION"],
                    view["DATE_CREATED"], view["DATE_MODIFIED"]);
                queryInfoObj.queryDescription = description;
                viewsDB.Add(queryInfoObj);
            }
            return viewsDB;
        }

        private void getDBProcAndFuncList()
        {
            /* Fetch Connection Schema Information And
             * Grab Procedures From DB:
             * type: 2 => Procedure
             * type: 3 => Function
             */

            connection.Open();
            DataTable procsDataTable = connection.GetSchema("Procedures");

            foreach (DataRow proc in procsDataTable.Rows)
            {
                string _type = proc["PROCEDURE_TYPE"].ToString(),
                        _def  = proc["PROCEDURE_DEFINITION"].ToString(),
                        _name = proc["PROCEDURE_NAME"].ToString();

                /* As long as OleDB.12.0 Throws An Error When Trying To Derive Procedure Parameters, 
                    * Parse Those Pararmeters Explicitly => Using RegExp 
                    * The Idea Is: Get All Bracketed Substrings From Procesure._def
                    * And Compare Them With Fields Names And Table Names Previously 
                    * Pulled From DB in getDBInfo();
                    */

                // Procedure
                if (_type == "2")
                {
                    DBProcedureInfo procInfoObj = new DBProcedureInfo();
                    procInfoObj.procName = _name;
                    procInfoObj.procString = _def;
                    procInfoObj.procParams = pullProcAndFuncParameters(query_def: _def);
                    procs.Add(procInfoObj);
                }

                // Function
                if (_type == "3")
                {
                    DBFunctionInfo funcInfoObj = new DBFunctionInfo();
                    funcInfoObj.funcName = _name;
                    funcInfoObj.funcString = _def;
                    funcInfoObj.funcParams = pullProcAndFuncParameters(query_def: _def);
                    functions.Add(funcInfoObj);
                }
            }

            connection.Close();
        }

        public static List<String> fetchFieldsByTableName(string tableName)
        {
            /* Method is used by executor. Get Info On Table From self.infoDB*/
            foreach (DBTableInfo tableInfo in infoDB)
                if (tableInfo.TableName == unwrap(tableName))
                    return tableInfo.Fields.Select(x => wrap(x)).ToList();
            return new List<String> {  };
        }

        private List<String> pullProcAndFuncParameters(string query_def)
        {
            // Pull Out Procedure Parameters
            Regex pattern = new Regex(@"\[(.*?)\]");
            MatchCollection matches = pattern.Matches(query_def);
            List<String> parameters = new List<String>();
            bool isParam;

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    isParam = true;
                    string matchVal = unwrap(match.Value);
                    // Look Up In Table Name And Fields -> infoDB
                    foreach (DBTableInfo table in infoDB)
                    {
                        if (table.TableName.ToLower() == matchVal.ToLower()
                            || table.Fields.Select(x => x.ToLower()).Contains(matchVal.ToLower()))
                        {
                            isParam = false;        // Found
                            break;                  // Exit Loop
                        }
                    }

                    if (isParam)
                        parameters.Add(match.Value);
                }
            }
            return parameters;
        }
        #endregion

        #region CustomTab

        #region CustomTabControls_AuxiliaryMethods
        private static string wrap(string str)
        {
            /* To be 'Access-Green', Methos Wraps String With [...] If It Has Space In It
             * e.g. 'Посетители Театра' should be converted to [Посетители Театра]
             */
            string wrapped = str;
            if (str.Contains(' '))
                wrapped = String.Format("[{0}]", str);
            return wrapped;
        }

        public static string unwrap(string str)
        {
            string unwrapped = str;
            int last = str.Length - 1;
            // '['+ <str> + ']'
            if ((str[0] == '[') && (str[last] == ']'))
            {
                unwrapped = str.Substring(1, last - 1);
            }

            return unwrapped;
        }

        private List<Control> getControllerSetBySelectedQueryType(string type)
        {
            /* Fetch Right Control Set By Query Type */
            List<Control> noValues = new List<Control>();
            switch (type)
            {
                case "SELECT":
                    fieldsCheckedListBox.Enabled = true;
                    return noValues;
                case "DELETE":
                    // Disable Multiple Tables Selection
                    tablesCheckedListBox.SelectionMode = SelectionMode.One;
                    // Disable Fields Selection
                    fieldsCheckedListBox.Enabled = false;
                    return noValues;
                case "UPDATE":
                case "INSERT":
                    tablesCheckedListBox.SelectionMode = SelectionMode.One;
                    fieldsCheckedListBox.Enabled = false;
                    return createUpdateAndInsertControllerSet();
                default:
                    return noValues;
            }
        }

        private void updateNewControllerSet(string type)
        {
            /* Method Updates newControllerSet Elements When Query Type Choice Made */
            newControllersSetSplitContainer.Panel1.Controls.Clear();
            newControllersSetSplitContainer.Panel2.Enabled = true;

            foreach (Control ctrl in getControllerSetBySelectedQueryType(type))
            {
                ctrl.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
                newControllersSetSplitContainer.Panel1.Controls.Add(ctrl);
            }

            // Disable Conditions Controllers Set If Needed
            if (type == "INSERT")
            {
                newControllersSetSplitContainer.Panel2.Enabled = false;
            }
        }

        private string getSelectedItemText(ComboBox box)
        {
            // Auxiliary Method Returning Item Selected In ComboBox
            return box.GetItemText(box.SelectedItem);
        }

        private List<String> getCheckedItemText(CheckedListBox box, ItemCheckEventArgs e)
        {
            // Auxiliary Method Returning All Checked Items In CheckedListBox

            // Value to return
            List<string> selectedElements = new List<string>();
            // Collect items
            foreach (var item in box.CheckedItems)
            {
                selectedElements.Add(item.ToString());
            }
            if (e.NewValue == CheckState.Checked)
            {
                selectedElements.Add(box.Items[e.Index].ToString());
            }
            else
            {
                selectedElements.Remove(box.Items[e.Index].ToString());
            }
            return selectedElements;
        }

        private void enableRestrictions(string type, ItemCheckEventArgs e)
        {
            /* Method Enables Restrictions For Controls When Table Select 
             * With Query Type Already Selected */
            switch (type)
            {
                case "SELECT":
                    // No restrictions for Tables for SELECT
                    break;
                case "DELETE":
                case "UPDATE":
                case "INSERT":
                    // Only 1 Table In Query Is Allowed, So Uncheck tablesCheckedListBox Items
                    if (e.NewValue == CheckState.Checked)
                        for (int i = 0; i < tablesCheckedListBox.Items.Count; i++)
                            if (e.Index != i)
                                tablesCheckedListBox.SetItemChecked(i, false);
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void categoryComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            /* categoryComboBox SelectedIndexChanged Event Handler */
            string selected = getSelectedItemText(categoryComboBox).ToUpper();
            // Save Choice
            commandExecutor.queryType = selected;
            // Dynamically Add New Controller According To Chosen Query Type
            updateNewControllerSet(selected);
        }

        private void tablesCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            /* tablesCheckedListBox ItemCheck Event Handler */
            enableRestrictions(commandExecutor.queryType, e);
            commandExecutor.queryTables = getCheckedItemText(tablesCheckedListBox, e);
            updateFieldsListBoxOnTableSelectChange();
            updateNewControllerSet(commandExecutor.queryType);
        }

        #region Fields_CheckedListBox
        private void updateFieldsListBoxOnTableSelectChange()
        {
            /* Method Updates Fields Available To Choose After User 
             * Triggers tablesCheckedListBox_ItemCheck()
             */

            fieldsConditionsComboBox.Items.Clear();
            possibleInsertOrUpdateFields.Clear();
            fieldsCheckedListBox.Items.Clear();

            foreach (String tableName in commandExecutor.queryTables)
            {
                // Get Info On Table From self.infoDB
                foreach (DBTableInfo tableInfo in infoDB)
                {
                    // Compare Tables' Names
                    if (tableInfo.TableName == unwrap(tableName))
                    {
                        // If Names Match, Iterate Over Table's Fields
                        foreach (String tableInfoField in tableInfo.Fields)
                        {
                            string formatted = String.Format(
                                "{0}.{1}",
                                tableName,
                                wrap(tableInfoField)
                            );
                            // Add Items To possibleInsertOrUpdateFields
                            possibleInsertOrUpdateFields.Add(tableInfoField);
                            // And Add Them To fieldsCheckedListBox.Items
                            fieldsCheckedListBox.Items.Add(formatted);
                            fieldsConditionsComboBox.Items.Add(formatted);
                        }
                        break;
                    }
                }
            }
        }

        private void fieldsCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            /* fieldsCheckedListBox ItemCheck Event Handler */
            commandExecutor.queryTableFields = getCheckedItemText(fieldsCheckedListBox, e);
        }
        #endregion

        #region Conditions_ControlSet
        /* Conditions_ControlSet ComboBoxes ItemIndexChanged Event Handlers */
        private void addEntryOnConditionsControlSetComboBoxItemSelected(ComboBox sender, string itemSelected)
        {
            /* In Common, Add Selected Entry To RichTextBox Text */
            int length = queryConditionsRichTextBox.Text.Length;
            if (sender.Items.Contains(lastAdded))
                queryConditionsRichTextBox.Text = queryConditionsRichTextBox.Text.Substring(
                    0, length - (lastAdded.Length + 1)
                ) + itemSelected + " ";
            else
                queryConditionsRichTextBox.Text += itemSelected + " ";
            lastAdded = itemSelected;
        }

        private void caseConditionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addEntryOnConditionsControlSetComboBoxItemSelected(
                caseConditionsComboBox,
                getSelectedItemText(box: caseConditionsComboBox)
            );
        }

        private void operatorsConditionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addEntryOnConditionsControlSetComboBoxItemSelected(
                operatorsConditionsComboBox,
                getSelectedItemText(box: operatorsConditionsComboBox)
            );
        }

        private void fieldsConditionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addEntryOnConditionsControlSetComboBoxItemSelected(
                fieldsConditionsComboBox,
                getSelectedItemText(box: fieldsConditionsComboBox)
            );
        }

        private void comparatorConditionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addEntryOnConditionsControlSetComboBoxItemSelected(
                comparatorConditionsComboBox,
                getSelectedItemText(box: comparatorConditionsComboBox)
            );
        }

        private void aggregateConditionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addEntryOnConditionsControlSetComboBoxItemSelected(
                aggregateConditionsComboBox,
                getSelectedItemText(box: aggregateConditionsComboBox)
            );
        }

        private void actionsConditionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addEntryOnConditionsControlSetComboBoxItemSelected(
                actionsConditionsComboBox,
                getSelectedItemText(box: actionsConditionsComboBox)
            );
        }
        #endregion

        #endregion

        #region ExistingTab
        #region ExistingTabCntrols_AuxiliaryMethods
        private void disableOptionsOnRadioButtonClick(GroupBox targetBox)
        {
            /* Change GroupBoxes Enabled State */
            List<Control> __allBoxes__ = new List<Control> {
                existingQueryGroupBox, existingProcGroupBox, existingFunctionGroupBox
            };

            foreach (GroupBox box in __allBoxes__)
            {
                if (box != targetBox)
                    box.Enabled = false;
            }
            targetBox.Enabled = true;
        }
        #endregion

        private void existingQueryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            disableOptionsOnRadioButtonClick(targetBox: existingQueryGroupBox);
            commandExecutor.existingTabBoxIndexChosen = 0;
        }

        private void existingProcRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            disableOptionsOnRadioButtonClick(targetBox: existingProcGroupBox);
            commandExecutor.existingTabBoxIndexChosen = 1;
        }

        private void existingFunctionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            disableOptionsOnRadioButtonClick(targetBox: existingFunctionGroupBox);
            commandExecutor.existingTabBoxIndexChosen = 2;
        }

        private void queryComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            /* queryComboBox SelectedIndexChanged Event Handler */
            string selectedStr = getSelectedItemText(queryComboBox);

            foreach (DBQueryInfo query in queries)
            {
                if (selectedStr == query.queryName)
                {
                    existingQueryDescrBox.Items.Clear();
                    foreach (string str in query.queryDescription.Split(';'))
                        existingQueryDescrBox.Items.Add(str);

                    commandExecutor.existingTabBoxIndexChosen = 0;
                    commandExecutor.exactQueryChosenString = query.queryString;
                    break;
                }
            }
        }

        private void existingProcComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* existingProcComboBox SelectedIndexChanged Event Handler */
            string selectedStr = getSelectedItemText(existingProcComboBox);

            foreach (DBProcedureInfo proc in procs)
            {
                if (selectedStr == proc.procName)
                {
                    insertParametersControlsList(
                        createParametersControlsList(proc.procParams),
                        existingProcParamField
                    );

                    commandExecutor.existingTabBoxIndexChosen = 1;
                    commandExecutor.exactProcOrFuncChosenString = proc.procString;
                    break;
                }
            }
        }

        private void existingFunctionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* existingFunctionComboBox SelectedIndexChanged Event Handler */
            string selectedStr = getSelectedItemText(existingFunctionComboBox);

            foreach (DBFunctionInfo func in functions)
            {
                if (selectedStr == func.funcName)
                {

                    insertParametersControlsList(
                        createParametersControlsList(func.funcParams),
                        existingFunctionParamField
                    );

                    commandExecutor.exactProcOrFuncChosenString = func.funcName;
                    commandExecutor.existingTabBoxIndexChosen = 2;
                    break;
                }
            }
        }

        private List<Control> createParametersControlsList(List<String> parameters)
        {
            /* Method Returns A Bunch Of Controls When 
             * Existing Procedure Or Function Selected.
             */

            // Value To Return
            List<Control> paramsSet = new List<Control>();

            // Create Labels and Controls In A Loop By 'parameters' List
            int i = 0;
            foreach (string p in parameters)
            {
                fieldLabel = new Label();
                fieldLabel.Text = p;
                fieldLabel.AutoSize = true;
                fieldLabel.Location = new Point(0, 0 + 40 * i);

                paramsSet.Add(fieldLabel);

                fieldTextBox = new TextBox();
                fieldTextBox.Location = new Point(0, 16 + 40 * i);
                fieldTextBox.Width = 264;
                paramsSet.Add(fieldTextBox);

                i++;
            }

            return paramsSet;
        }

        private void insertParametersControlsList(List<Control> parameters, Panel controlPanel)
        {
            /* After Creating Params List, Insert It Into The Targeting Panel */
            controlPanel.Controls.Clear();
            foreach (Control p in parameters)
            {
                p.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
                controlPanel.Controls.Add(p);
            }
        }
        #endregion

        #region Execute_Button
        private Dictionary<string, string> collectProcOrFuncParams(Panel controlsPanel)
        {
            /* Controls List look like: Label (Param Key), TextBox (Param Value), And So On.
             * So The Serializing Algorithm Is Not Flexible Due To The Possibility Of Panel Structure Change.
             * Fix This Method If Your Controls Panel Has Different Structure.
             */
            Dictionary<string, string> __params__ = new Dictionary<string, string>();

            if (commandExecutor.exactProcOrFuncQueryParams != null && commandExecutor.exactProcOrFuncQueryParams.Count > 0)
            {
                commandExecutor.exactProcOrFuncQueryParams.Clear();
            }

            for (int i = 0; i < controlsPanel.Controls.Count - 1; i+=2)
            {
                __params__.Add(
                    wrap(controlsPanel.Controls[i].Text),        // Param Key
                    controlsPanel.Controls[i + 1].Text           // Param Value
                );
            }

            return __params__;
        }

        private void setFinalValues()
        {
            /* Method Is Called On 'Execute' Button Click Before Query Execution
             * And Sets All Possible Values For Executor;
             */

            // For Each TextField Where User Has Free Ability To Write, Remove Unnecessary Escapes
            string toRemoveEscapes = @"\r|\r\n?|\n|\s+";
            string toReplaceEscapes = " ";


            if (commandExecutor.tabChosenIndex == 0)
            {
                // CustomTab
                if (commandExecutor.queryType != "INSERT")
                {
                    commandExecutor.queryConditions = System.Text.RegularExpressions.Regex.Replace(
                        queryConditionsRichTextBox.Text,
                        toRemoveEscapes,
                        toReplaceEscapes
                    ).Trim();
                }

                //commandExecutor.exactProcOrFuncQueryParams.Clear();
                commandExecutor.exactProcOrFuncQueryParams = collectProcOrFuncParams(
                    controlsPanel: newControllersSetSplitContainer.Panel1
                );
            }
            else if(commandExecutor.tabChosenIndex == 1)
            {
                // ExistingTab
                if (commandExecutor.existingTabBoxIndexChosen == 1)
                {
                    //commandExecutor.exactProcOrFuncQueryParams.Clear();
                    commandExecutor.exactProcOrFuncQueryParams = collectProcOrFuncParams(existingProcParamField);
                }
                else if (commandExecutor.existingTabBoxIndexChosen == 2)
                {
                    //commandExecutor.exactProcOrFuncQueryParams.Clear();
                    commandExecutor.exactProcOrFuncQueryParams = collectProcOrFuncParams(existingFunctionParamField);
                }
            }
            else if (commandExecutor.tabChosenIndex == 2)
            {
                // SQLTab
                commandExecutor.SQLQueryString = System.Text.RegularExpressions.Regex.Replace(
                    SQLTextBox.Text,
                    toRemoveEscapes,
                    toReplaceEscapes
                ).Trim();
            }
        }

        private bool allChecksValid()
        {
            /* Pre-Execute Query Checks */
            bool ok = true;
            return ok;
        }

        private bool beforeExecution()
        {
            /* Method is called before Executing String Assembled 
             * From Controllers Set Created By user.
             * Throw New Exception If Any Of Checks Failed
             */
            setFinalValues();
            return allChecksValid();
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            /* executeButton Click Event Handler */
            
            // Check If User Controller Set Is Valid And Execute Value
            if (beforeExecution())
            {
                // Result Returned From commandExecutor
                List<string[]> resultFetched = commandExecutor.executeQueryString();
                // Handle Fetched Data View Display
                displayData(resultFetched);
            }
        }

        private void setDataGridViewHeaders(List<string[]> headers)
        {
            /* Set dataGridView Headers From List Of Headers */
            resultDataGridView.Columns.Clear();
            try
            {
                resultDataGridView.ColumnCount = headers.Count;

                for (int i = 0; i < resultDataGridView.Columns.Count; i++)
                {
                    string[] fieldPair = headers[i][0].Split(':');
                    resultDataGridView.Columns[i].Name = fieldPair[1];
                }
            }
            catch (System.NullReferenceException)
            {
                // Console.WriteLine("No headers was returned from query result");
            }
        }

        private void displayData(List<string[]> result)
        {
            /* Method Displays Data Returned From CommandExecutor.executeQueryString() */

            if (tempLabel.Visible) tempLabel.Visible = false;

            // Clear Previous Result
            resultDataGridView.Rows.Clear();

            // Add Columns And Set Headers First. Headers List Could Be Fetched From CommandExecutor.headers
            setDataGridViewHeaders(commandExecutor.resultingTableHeaders);

            // Fill resultDataGridView With Data Fetched
            int i = 0;
            foreach (string[] row in result)
            {
                resultDataGridView.Rows.Add(row);
                DataGridViewRow tableRow = resultDataGridView.Rows[i];
                tableRow.HeaderCell.Value = (tableRow.Index + 1).ToString();

                if (i++ % 2 == 1)
                    tableRow.DefaultCellStyle.BackColor = Color.LightGray;
            }

            foreach (DataGridViewColumn column in resultDataGridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        #endregion

        #region DataGridView
        private void resultDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            resultDataGridView.Columns.Clear();
            resultDataGridView.Rows.Clear();
            resultDataGridView.Refresh();
            if (!tempLabel.Visible) tempLabel.Visible = true;
        }
        #endregion
    }

    #region DataAccessClasses
    class DBTableInfo
    {
        /* Class Representing Separate Table Info Structure In Current DB Connection Schema  */
        public string TableName { get; set; }
        public IList<String> Fields { get; set; }
    }

    class DBQueryInfo
    {
        /* Class Representing Separate Query Info Saved In Connected DataBase */
        public string queryName { get; set; }
        public string queryString { get; set; }
        public string queryDescription {get; set; }
    }

    class DBProcedureInfo
    {
        /* Class Representing DB Procedure Info Structure */
        public string procName { get; set; }
        public string procString { get; set; }
        public List<String> procParams { get; set; }
    }
    class DBFunctionInfo
    {
        /* Class representing DB Function Info Structire */
        public string funcName { get; set; }
        public string funcString { get; set; }
        public List<String> funcParams { get; set; }
    }
    #endregion

    class CommandExecutor
    {
        OleDbConnection execConn;
        OleDbCommand execCmd;
        // Query Templates
        string SELECT = "SELECT {0} FROM {1} {2}",
               DELETE = "DELETE FROM {0} {1}",
               UPDATE = "UPDATE {0} SET {1} {2}",
               INSERT = "INSERT INTO {0} ({1}) VALUES ({2})";

        public byte tabChosenIndex = 0;
        public byte existingTabBoxIndexChosen = 0;

        // exact{...} Are String Attributes Representing Option Selected By User On existingTab
        // One Of That Will Be Executed If tabChosenIndex == 1
        public string exactQueryChosenString { get; set; }
        public string exactProcOrFuncChosenString { get; set; }
        public Dictionary<String, String> exactProcOrFuncQueryParams { get; set; }

        // SQL Query String From SQLPage => Will Be Executed If tabChosenIndex == 2
        public string SQLQueryString { get; set; }
        public List<string[]> resultingTableHeaders { get; set; }
        
        // SELECT, DELETE, UPDATE, INSERT
        public string       queryType { get; set; }
        public List<String> queryTableFields = new List<String>();
        public List<String> queryTables = new List<String>();
        // WHERE, START WITH, HAVING, CONNECT BY
        public string queryConditions = "WHERE NULL IS NULL";

        public CommandExecutor(OleDbConnection connection, OleDbCommand command)
        {
            // Constructor
            this.execConn = connection;
            this.execCmd = command;
        }

        private string dictToString(Dictionary<string, string> dict, bool needNames)
        {
            /* Methods converts Dictionary<string, string> (no template) to a string 
             * bool needNames special: true if Fields Names Are Required, false - Otherwise
             */
            StringBuilder sb = new System.Text.StringBuilder();

            foreach (KeyValuePair<string, string> value in dict)
            {
                if (value.Value.Length != 0)
                {
                    if (needNames)
                        sb.Append(String.Format("{0}={1},", value.Key, value.Value));
                    else
                        sb.Append(String.Format("{0},", value.Value));
                }
            }

            try
            {
                sb.Remove(sb.Length - 1, 1);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                Console.WriteLine("Cannot execute UPDATE or INSERT without new fields values");
            }

            return sb.ToString();
        }

        private string listToString(List<String> list, byte special)
        {
            /* Methods converts List<String> (no template) to a string 
             * byte special values meaning:
             * 0: Response To Build Fields List (return '*' if empty)
             * 1: Response To Build Tables List (return error if empty)
             * 2: Response To Build Values List (return error if empty)
             */

            if (list.Count() == 0)
            {
                switch (special)
                {
                    case 0:
                        return "*";
                    case 1:
                        Console.WriteLine("Tables list must not be empty");
                        break;
                    case 2:
                        Console.WriteLine("Please, specify new values list");
                        break;
                    default:
                        break;
                }
            }
            
            StringBuilder sb = new System.Text.StringBuilder();
            foreach (string str in list)
            {
                sb.Append(str).Append(",");
            }
            // Remove Last Delimeter
            try
            {
                sb.Remove(sb.Length - 1, 1);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                Console.WriteLine("List is empty");
            }
            return sb.ToString();  
        }

        private string generateCustomStringToExecute()
        {
            /* Genearate String From Custom Page */

            switch (queryType)
            {
                case "SELECT":
                    // "SELECT {fields} FROM {table} WHERE {condition}"
                    return String.Format(
                        SELECT,
                        listToString(queryTableFields, 0),
                        listToString(queryTables, 1),
                        queryConditions
                    );
                case "DELETE":
                    // "DELETE FROM {table} WHERE {condition}"
                    return String.Format(
                        DELETE,
                        listToString(queryTables, 1),
                        queryConditions
                    );
                case "UPDATE":
                    // "UPDATE {table} SET {values} WHERE {condition}"
                    return String.Format(
                        UPDATE,
                        listToString(queryTables, 1),
                        dictToString(exactProcOrFuncQueryParams, needNames: true),
                        queryConditions
                    );
                case "INSERT":
                    // "INSERT INTO {table} {fields} VALUES ({values})"
                    string tableName = listToString(queryTables, 1);

                    return String.Format(
                        INSERT,
                        tableName,
                        listToString(Form1.fetchFieldsByTableName(tableName), 2),
                        dictToString(exactProcOrFuncQueryParams, needNames: false)
                    );

                default: return "";
            }
        }

        private string chooseStringToExecute()
        {
            /* Method Selects String To Execute According To selectedTabIndex */
            string toRet = "";

            switch (tabChosenIndex)
            {
                case 0:
                    // From customPage Tab
                    toRet = generateCustomStringToExecute();
                    break;
                case 1:
                    // From existingPage Tab
                    if (existingTabBoxIndexChosen == 0)
                        toRet = exactQueryChosenString;
                    else
                        toRet = exactProcOrFuncChosenString;
                    break;
                case 2:
                    // From SQLPage Tab
                    toRet = SQLQueryString;
                    break;
                default: 
                    break;
            }

            return System.Text.RegularExpressions.Regex.Replace(
                toRet,
                @"\r|\r\n?|\n|\s+",
                " "
            ).Trim();
        }

        private List<string[]> fetchResultingTableFields(DataTable schemaTable)
        {
            /* Method Fetchet Column Names In Query Execution Result */
            List<string[]> headers = new List<string[]>();
            foreach (DataRow field in schemaTable.Rows)
            {
                int count = schemaTable.Columns.Count;
                string[] sepField = new string[count];

                for (int i = 0; i < count; i++)
                {
                    DataColumn prop = schemaTable.Columns[i];
                    sepField[i] = String.Format(
                        "{0}:{1}",
                        prop.ColumnName,
                        field[prop].ToString()
                    );
                }
                headers.Add(sepField);
            }
            return headers;
        }

        private string generateStringToReturnResult(string stringToExecute)
        {
            /* If Query Being Executed Is Not Mean To Return Result To Display
             * (e.g. INSERT, DELETE or UPDATE Query Types),
             * Nonetheless, To Display Row(s) To Be Changed,
             * There Is A Need To Make New 'SELECT' Requset
             * With Given Parameters Set (table_name, conditions);
             */
            Console.WriteLine(stringToExecute);

            // If Request Comes From CustomTab, We Already Have All Collection
            if (this.tabChosenIndex == 0)
            {
                return String.Format(
                    SELECT,
                    "*",                                    // Fields
                    listToString(queryTables, 1),           // Tables
                    queryConditions                         // Contitions
                );
            }

            // Otherwise, If Request Comes From ExistingTab Or SQLTab
            else
            {
                // Parse Table Name From stringToExecute
                string tableName = "",
                       conditionsString = "";

                Match update = new Regex(@"UPDATE\s+(.*?)\s+").Match(stringToExecute);
                Match insert = new Regex(@"INSERT\s+INTO\s+(.*?)\s+").Match(stringToExecute);
                Match delete = new Regex(@"DELETE\s+FROM\s+(.*?)\s+").Match(stringToExecute);

                List<string> matching = new List<string> { 
                    update.Groups[1].ToString(), 
                    insert.Groups[1].ToString(), 
                    delete.Groups[1].ToString()
                };

                matching.RemoveAll(x => x.Length == 0);
                tableName = matching[0];

                // Collect Conditions
                // Condition Keywords Could Repeat In One Query String
                // So We Look For The Minimum Index And substr To The End
                StringComparison comp = StringComparison.OrdinalIgnoreCase;
                int isWHERE      = stringToExecute.IndexOf("WHERE", comp),
                    isHAVING     = stringToExecute.IndexOf("HAVING", comp),
                    isCONNECT_BY = stringToExecute.IndexOf("CONNECT BY", comp),
                    isSTART_WITH = stringToExecute.IndexOf("START WITH", comp);

                List<int> indicies = new List<int> { isWHERE, isHAVING, isCONNECT_BY, isSTART_WITH };
                indicies.RemoveAll(x => x == -1);

                try
                {
                    int start = indicies.Max(),
                        end = stringToExecute.Length - start;
                    conditionsString = stringToExecute.Substring(start, end);
                }
                catch (InvalidOperationException)
                {
                    // Conditions Not Found
                    Console.WriteLine("No Conditions Found!");
                    // Build Conditions From Given Fields

                    conditionsString = " WHERE " + dictToString(exactProcOrFuncQueryParams, needNames: true);
                }

                Console.WriteLine(String.Format(
                    SELECT,
                    "*",
                    tableName,
                    conditionsString
                ));

                return String.Format(
                    SELECT,
                    "*",
                    tableName,
                    conditionsString
                );
            }
        }

        private List<string[]> readFromReader(OleDbDataReader reader)
        {
            /* Read Rows One By One From execReader And Store Into List<string[]> */
            List<string[]> result = new List<string[]>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string[] row = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader[i].ToString();
                    }
                    result.Add(row);
                }
            }
            else
            {
                Console.WriteLine("0 Rows Fetched!");
            }
            return result;
        }

        private bool queryIsPlainText()
        {
            /* Query Is Plain Text ONLY If tabChosenIndex != 1 (i.e. 0 or 2) */
            if (tabChosenIndex != 1)
                return true;
            else
                return false;
        }

        public List<string[]> executeQueryString()
        {
            /* Method Executes Final Query Selected Or Generated By User And Returns Execution Result */

            List<string[]> result = new List<string[]>();
            bool fromExistingQuery = ((tabChosenIndex == 1) && (existingTabBoxIndexChosen == 0));
            bool fromExistingFunction = ((tabChosenIndex == 1) && (existingTabBoxIndexChosen == 2));

            string stringToExecute = chooseStringToExecute();
            Console.WriteLine(stringToExecute);

            try
            {
                execConn.Open();

                // If Given Query Is Custom Or SQL Query Or Stored View
                if ((queryIsPlainText()) || fromExistingQuery)
                {
                    // Execute Query As A Text And Get Result
                    execCmd.CommandType = CommandType.Text;
                    execCmd.CommandText = stringToExecute;
                    OleDbDataReader execReader = execCmd.ExecuteReader();
                    result = readFromReader(execReader);

                    if (stringToExecute.StartsWith("SELECT", StringComparison.InvariantCultureIgnoreCase))
                    {
                        // Retrieve Table Schema
                        DataTable schemaTable = execReader.GetSchemaTable();
                        resultingTableHeaders = fetchResultingTableFields(schemaTable);
                        execReader.Close();
                    }
                    else
                    {
                        execReader.Close();
                        // Execute New Query To Get Changed Row(s) For Displaying
                        execCmd.CommandText = generateStringToReturnResult(stringToExecute);
                        OleDbDataReader newExecReader = execCmd.ExecuteReader();
                        result = readFromReader(newExecReader);
                        // Retrieve Table Schema
                        DataTable newSchemaTable = newExecReader.GetSchemaTable();
                        resultingTableHeaders = fetchResultingTableFields(newSchemaTable);
                        execReader.Close();
                    }
                }

                // If Given Query Is Stored Function 
                else if (fromExistingFunction)
                {
                    if ((exactProcOrFuncQueryParams != null) && (exactProcOrFuncQueryParams.Count > 0))
                        foreach (KeyValuePair<string, string> parameter in exactProcOrFuncQueryParams)
                        {
                            execCmd.Parameters.AddWithValue(Form1.unwrap(parameter.Key), parameter.Value);
                        }

                    execCmd.CommandType = CommandType.Text;
                    execCmd.CommandText = "SELECT * FROM [" + stringToExecute + "]";
                    OleDbDataReader newExecReader = execCmd.ExecuteReader();
                    result = readFromReader(newExecReader);
                    DataTable newSchemaTable = newExecReader.GetSchemaTable();
                    resultingTableHeaders = fetchResultingTableFields(newSchemaTable);
                    newExecReader.Dispose();
                }

                // If Given Query Is Stored Procedure 
                else
                {
                    // Execute Stored Procedure
                    if ((exactProcOrFuncQueryParams != null) && (exactProcOrFuncQueryParams.Count > 0))
                        foreach (KeyValuePair<string, string> parameter in exactProcOrFuncQueryParams)
                        {
                            execCmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }
                    
                    execCmd.CommandText = stringToExecute;
                    int countChanged = execCmd.ExecuteNonQuery();
                    Console.WriteLine(String.Format("{0} rows affected", countChanged));
                    execCmd.Parameters.Clear();
                }
            }
            catch (OleDbException)
            {
                Console.WriteLine("Query is incorrect. Check spelling");
            }
            finally
            {
                if (execConn != null)
                    execConn.Close();
            }

            return result;  
        }

        private string createGeneratedQueryToSave(string queryName, string stringToExecute)
        {
            /* After Successful Execution, Call This Method To Save Generated Query  */
            string sampleSQL = "CREATE PROCEDURE {0} AS {1} GO;";
            return String.Format(sampleSQL, queryName, stringToExecute);
        }
    }
}