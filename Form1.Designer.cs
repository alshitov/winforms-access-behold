namespace BDZ
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.executeButton = new System.Windows.Forms.Button();
            this.tablesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.fieldsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.resultDataGridView = new System.Windows.Forms.DataGridView();
            this.mainTabWindow = new System.Windows.Forms.TabControl();
            this.customPage = new System.Windows.Forms.TabPage();
            this.newControllersSet = new System.Windows.Forms.Panel();
            this.newControllersSetSplitContainer = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.caseConditionsComboBox = new System.Windows.Forms.ComboBox();
            this.operatorsConditionsComboBox = new System.Windows.Forms.ComboBox();
            this.fieldsConditionsComboBox = new System.Windows.Forms.ComboBox();
            this.comparatorConditionsComboBox = new System.Windows.Forms.ComboBox();
            this.aggregateConditionsComboBox = new System.Windows.Forms.ComboBox();
            this.actionsConditionsComboBox = new System.Windows.Forms.ComboBox();
            this.queryConditionsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.conditionsSetLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.existingPage = new System.Windows.Forms.TabPage();
            this.existingFunctionRadioButton = new System.Windows.Forms.RadioButton();
            this.existingFunctionGroupBox = new System.Windows.Forms.GroupBox();
            this.existingFunctionParamField = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.existingFunctionComboBox = new System.Windows.Forms.ComboBox();
            this.existingFunctionLabel = new System.Windows.Forms.Label();
            this.existingProcRadioButton = new System.Windows.Forms.RadioButton();
            this.existingProcGroupBox = new System.Windows.Forms.GroupBox();
            this.existingProcParamField = new System.Windows.Forms.Panel();
            this.procedureParametersLabel = new System.Windows.Forms.Label();
            this.existingProcComboBox = new System.Windows.Forms.ComboBox();
            this.procedureLabel = new System.Windows.Forms.Label();
            this.existingQueryRadioButton = new System.Windows.Forms.RadioButton();
            this.existingQueryGroupBox = new System.Windows.Forms.GroupBox();
            this.existingQueryDescrBox = new System.Windows.Forms.ListBox();
            this.queryLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.queryComboBox = new System.Windows.Forms.ComboBox();
            this.SQLPage = new System.Windows.Forms.TabPage();
            this.SQLTextBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tempLabel = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).BeginInit();
            this.mainTabWindow.SuspendLayout();
            this.customPage.SuspendLayout();
            this.newControllersSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newControllersSetSplitContainer)).BeginInit();
            this.newControllersSetSplitContainer.Panel2.SuspendLayout();
            this.newControllersSetSplitContainer.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.existingPage.SuspendLayout();
            this.existingFunctionGroupBox.SuspendLayout();
            this.existingProcGroupBox.SuspendLayout();
            this.existingQueryGroupBox.SuspendLayout();
            this.SQLPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // executeButton
            // 
            this.executeButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.executeButton.BackColor = System.Drawing.SystemColors.Desktop;
            this.executeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.executeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.executeButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.executeButton.Location = new System.Drawing.Point(332, 479);
            this.executeButton.MinimumSize = new System.Drawing.Size(100, 0);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(197, 23);
            this.executeButton.TabIndex = 0;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = false;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // tablesCheckedListBox
            // 
            this.tablesCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablesCheckedListBox.FormattingEnabled = true;
            this.tablesCheckedListBox.HorizontalScrollbar = true;
            this.tablesCheckedListBox.Location = new System.Drawing.Point(-1, -1);
            this.tablesCheckedListBox.MinimumSize = new System.Drawing.Size(150, 100);
            this.tablesCheckedListBox.Name = "tablesCheckedListBox";
            this.tablesCheckedListBox.Size = new System.Drawing.Size(404, 139);
            this.tablesCheckedListBox.TabIndex = 11;
            this.tablesCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.tablesCheckedListBox_ItemCheck);
            // 
            // fieldsCheckedListBox
            // 
            this.fieldsCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldsCheckedListBox.FormattingEnabled = true;
            this.fieldsCheckedListBox.HorizontalScrollbar = true;
            this.fieldsCheckedListBox.Location = new System.Drawing.Point(3, 0);
            this.fieldsCheckedListBox.MinimumSize = new System.Drawing.Size(150, 100);
            this.fieldsCheckedListBox.Name = "fieldsCheckedListBox";
            this.fieldsCheckedListBox.Size = new System.Drawing.Size(393, 139);
            this.fieldsCheckedListBox.TabIndex = 13;
            this.fieldsCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.fieldsCheckedListBox_ItemCheck);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(6, 19);
            this.categoryComboBox.MinimumSize = new System.Drawing.Size(150, 0);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(802, 21);
            this.categoryComboBox.TabIndex = 4;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged_1);
            // 
            // categoryLabel
            // 
            this.categoryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(6, 3);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(49, 13);
            this.categoryLabel.TabIndex = 8;
            this.categoryLabel.Text = "Category";
            // 
            // resultDataGridView
            // 
            this.resultDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.resultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGridView.Location = new System.Drawing.Point(12, 508);
            this.resultDataGridView.Name = "resultDataGridView";
            this.resultDataGridView.Size = new System.Drawing.Size(823, 269);
            this.resultDataGridView.TabIndex = 15;
            this.resultDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultDataGridView_CellContentClick);
            // 
            // mainTabWindow
            // 
            this.mainTabWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabWindow.Controls.Add(this.customPage);
            this.mainTabWindow.Controls.Add(this.existingPage);
            this.mainTabWindow.Controls.Add(this.SQLPage);
            this.mainTabWindow.Cursor = System.Windows.Forms.Cursors.Default;
            this.mainTabWindow.Location = new System.Drawing.Point(12, 12);
            this.mainTabWindow.Name = "mainTabWindow";
            this.mainTabWindow.SelectedIndex = 0;
            this.mainTabWindow.Size = new System.Drawing.Size(822, 461);
            this.mainTabWindow.TabIndex = 18;
            this.mainTabWindow.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.mainTabWindow_Selecting);
            // 
            // customPage
            // 
            this.customPage.AutoScroll = true;
            this.customPage.Controls.Add(this.newControllersSet);
            this.customPage.Controls.Add(this.label1);
            this.customPage.Controls.Add(this.splitContainer1);
            this.customPage.Controls.Add(this.categoryLabel);
            this.customPage.Controls.Add(this.categoryComboBox);
            this.customPage.Location = new System.Drawing.Point(4, 22);
            this.customPage.Name = "customPage";
            this.customPage.Padding = new System.Windows.Forms.Padding(3);
            this.customPage.Size = new System.Drawing.Size(814, 435);
            this.customPage.TabIndex = 0;
            this.customPage.Text = "Custom";
            this.customPage.UseVisualStyleBackColor = true;
            // 
            // newControllersSet
            // 
            this.newControllersSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newControllersSet.AutoScroll = true;
            this.newControllersSet.Controls.Add(this.newControllersSetSplitContainer);
            this.newControllersSet.Location = new System.Drawing.Point(6, 203);
            this.newControllersSet.Name = "newControllersSet";
            this.newControllersSet.Size = new System.Drawing.Size(802, 229);
            this.newControllersSet.TabIndex = 14;
            // 
            // newControllersSetSplitContainer
            // 
            this.newControllersSetSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newControllersSetSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.newControllersSetSplitContainer.Name = "newControllersSetSplitContainer";
            // 
            // newControllersSetSplitContainer.Panel1
            // 
            this.newControllersSetSplitContainer.Panel1.AccessibleName = "fieldsBunch";
            this.newControllersSetSplitContainer.Panel1.AutoScroll = true;
            // 
            // newControllersSetSplitContainer.Panel2
            // 
            this.newControllersSetSplitContainer.Panel2.AccessibleName = "conditionsControls";
            this.newControllersSetSplitContainer.Panel2.AutoScroll = true;
            this.newControllersSetSplitContainer.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.newControllersSetSplitContainer.Panel2.Controls.Add(this.queryConditionsRichTextBox);
            this.newControllersSetSplitContainer.Panel2.Controls.Add(this.conditionsSetLabel);
            this.newControllersSetSplitContainer.Size = new System.Drawing.Size(802, 232);
            this.newControllersSetSplitContainer.SplitterDistance = 401;
            this.newControllersSetSplitContainer.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.caseConditionsComboBox);
            this.flowLayoutPanel1.Controls.Add(this.operatorsConditionsComboBox);
            this.flowLayoutPanel1.Controls.Add(this.fieldsConditionsComboBox);
            this.flowLayoutPanel1.Controls.Add(this.comparatorConditionsComboBox);
            this.flowLayoutPanel1.Controls.Add(this.aggregateConditionsComboBox);
            this.flowLayoutPanel1.Controls.Add(this.actionsConditionsComboBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 140);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(393, 86);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // caseConditionsComboBox
            // 
            this.caseConditionsComboBox.FormattingEnabled = true;
            this.caseConditionsComboBox.Location = new System.Drawing.Point(3, 3);
            this.caseConditionsComboBox.Name = "caseConditionsComboBox";
            this.caseConditionsComboBox.Size = new System.Drawing.Size(190, 21);
            this.caseConditionsComboBox.TabIndex = 2;
            this.caseConditionsComboBox.Text = "Case";
            this.caseConditionsComboBox.SelectedIndexChanged += new System.EventHandler(this.caseConditionsComboBox_SelectedIndexChanged);
            // 
            // operatorsConditionsComboBox
            // 
            this.operatorsConditionsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.operatorsConditionsComboBox.FormattingEnabled = true;
            this.operatorsConditionsComboBox.Location = new System.Drawing.Point(199, 3);
            this.operatorsConditionsComboBox.Name = "operatorsConditionsComboBox";
            this.operatorsConditionsComboBox.Size = new System.Drawing.Size(190, 21);
            this.operatorsConditionsComboBox.TabIndex = 5;
            this.operatorsConditionsComboBox.Text = "Operator";
            this.operatorsConditionsComboBox.SelectedIndexChanged += new System.EventHandler(this.operatorsConditionsComboBox_SelectedIndexChanged);
            // 
            // fieldsConditionsComboBox
            // 
            this.fieldsConditionsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldsConditionsComboBox.FormattingEnabled = true;
            this.fieldsConditionsComboBox.Location = new System.Drawing.Point(3, 30);
            this.fieldsConditionsComboBox.Name = "fieldsConditionsComboBox";
            this.fieldsConditionsComboBox.Size = new System.Drawing.Size(190, 21);
            this.fieldsConditionsComboBox.TabIndex = 3;
            this.fieldsConditionsComboBox.Text = "Field";
            this.fieldsConditionsComboBox.SelectedIndexChanged += new System.EventHandler(this.fieldsConditionsComboBox_SelectedIndexChanged);
            // 
            // comparatorConditionsComboBox
            // 
            this.comparatorConditionsComboBox.FormattingEnabled = true;
            this.comparatorConditionsComboBox.Location = new System.Drawing.Point(199, 30);
            this.comparatorConditionsComboBox.Name = "comparatorConditionsComboBox";
            this.comparatorConditionsComboBox.Size = new System.Drawing.Size(190, 21);
            this.comparatorConditionsComboBox.TabIndex = 4;
            this.comparatorConditionsComboBox.Text = "Comparator";
            this.comparatorConditionsComboBox.SelectedIndexChanged += new System.EventHandler(this.comparatorConditionsComboBox_SelectedIndexChanged);
            // 
            // aggregateConditionsComboBox
            // 
            this.aggregateConditionsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.aggregateConditionsComboBox.FormattingEnabled = true;
            this.aggregateConditionsComboBox.Location = new System.Drawing.Point(3, 57);
            this.aggregateConditionsComboBox.Name = "aggregateConditionsComboBox";
            this.aggregateConditionsComboBox.Size = new System.Drawing.Size(190, 21);
            this.aggregateConditionsComboBox.TabIndex = 0;
            this.aggregateConditionsComboBox.Text = "Aggregate";
            this.aggregateConditionsComboBox.SelectedIndexChanged += new System.EventHandler(this.aggregateConditionsComboBox_SelectedIndexChanged);
            // 
            // actionsConditionsComboBox
            // 
            this.actionsConditionsComboBox.FormattingEnabled = true;
            this.actionsConditionsComboBox.Location = new System.Drawing.Point(199, 57);
            this.actionsConditionsComboBox.Name = "actionsConditionsComboBox";
            this.actionsConditionsComboBox.Size = new System.Drawing.Size(190, 21);
            this.actionsConditionsComboBox.TabIndex = 0;
            this.actionsConditionsComboBox.Text = "Action";
            this.actionsConditionsComboBox.SelectedIndexChanged += new System.EventHandler(this.actionsConditionsComboBox_SelectedIndexChanged);
            // 
            // queryConditionsRichTextBox
            // 
            this.queryConditionsRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.queryConditionsRichTextBox.Location = new System.Drawing.Point(4, 21);
            this.queryConditionsRichTextBox.Name = "queryConditionsRichTextBox";
            this.queryConditionsRichTextBox.Size = new System.Drawing.Size(393, 113);
            this.queryConditionsRichTextBox.TabIndex = 1;
            this.queryConditionsRichTextBox.Text = "";
            // 
            // conditionsSetLabel
            // 
            this.conditionsSetLabel.AutoSize = true;
            this.conditionsSetLabel.Location = new System.Drawing.Point(4, 4);
            this.conditionsSetLabel.Name = "conditionsSetLabel";
            this.conditionsSetLabel.Size = new System.Drawing.Size(56, 13);
            this.conditionsSetLabel.TabIndex = 0;
            this.conditionsSetLabel.Text = "Conditions";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "label1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 59);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tablesCheckedListBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fieldsCheckedListBox);
            this.splitContainer1.Size = new System.Drawing.Size(802, 145);
            this.splitContainer1.SplitterDistance = 402;
            this.splitContainer1.TabIndex = 15;
            // 
            // existingPage
            // 
            this.existingPage.AutoScroll = true;
            this.existingPage.Controls.Add(this.existingFunctionRadioButton);
            this.existingPage.Controls.Add(this.existingFunctionGroupBox);
            this.existingPage.Controls.Add(this.existingProcRadioButton);
            this.existingPage.Controls.Add(this.existingProcGroupBox);
            this.existingPage.Controls.Add(this.existingQueryRadioButton);
            this.existingPage.Controls.Add(this.existingQueryGroupBox);
            this.existingPage.Location = new System.Drawing.Point(4, 22);
            this.existingPage.Name = "existingPage";
            this.existingPage.Padding = new System.Windows.Forms.Padding(3);
            this.existingPage.Size = new System.Drawing.Size(814, 435);
            this.existingPage.TabIndex = 1;
            this.existingPage.Text = "Existing";
            this.existingPage.UseVisualStyleBackColor = true;
            // 
            // existingFunctionRadioButton
            // 
            this.existingFunctionRadioButton.AutoSize = true;
            this.existingFunctionRadioButton.Location = new System.Drawing.Point(13, 522);
            this.existingFunctionRadioButton.Name = "existingFunctionRadioButton";
            this.existingFunctionRadioButton.Size = new System.Drawing.Size(147, 17);
            this.existingFunctionRadioButton.TabIndex = 22;
            this.existingFunctionRadioButton.Text = "Execute Existing Function";
            this.existingFunctionRadioButton.UseVisualStyleBackColor = true;
            this.existingFunctionRadioButton.CheckedChanged += new System.EventHandler(this.existingFunctionRadioButton_CheckedChanged);
            // 
            // existingFunctionGroupBox
            // 
            this.existingFunctionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.existingFunctionGroupBox.Controls.Add(this.existingFunctionParamField);
            this.existingFunctionGroupBox.Controls.Add(this.label4);
            this.existingFunctionGroupBox.Controls.Add(this.existingFunctionComboBox);
            this.existingFunctionGroupBox.Controls.Add(this.existingFunctionLabel);
            this.existingFunctionGroupBox.Location = new System.Drawing.Point(6, 535);
            this.existingFunctionGroupBox.Name = "existingFunctionGroupBox";
            this.existingFunctionGroupBox.Size = new System.Drawing.Size(795, 236);
            this.existingFunctionGroupBox.TabIndex = 21;
            this.existingFunctionGroupBox.TabStop = false;
            // 
            // existingFunctionParamField
            // 
            this.existingFunctionParamField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.existingFunctionParamField.AutoScroll = true;
            this.existingFunctionParamField.Location = new System.Drawing.Point(6, 69);
            this.existingFunctionParamField.Name = "existingFunctionParamField";
            this.existingFunctionParamField.Size = new System.Drawing.Size(783, 161);
            this.existingFunctionParamField.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Function Parameters";
            // 
            // existingFunctionComboBox
            // 
            this.existingFunctionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.existingFunctionComboBox.FormattingEnabled = true;
            this.existingFunctionComboBox.Location = new System.Drawing.Point(6, 29);
            this.existingFunctionComboBox.Name = "existingFunctionComboBox";
            this.existingFunctionComboBox.Size = new System.Drawing.Size(783, 21);
            this.existingFunctionComboBox.TabIndex = 19;
            this.existingFunctionComboBox.SelectedIndexChanged += new System.EventHandler(this.existingFunctionComboBox_SelectedIndexChanged);
            // 
            // existingFunctionLabel
            // 
            this.existingFunctionLabel.AutoSize = true;
            this.existingFunctionLabel.Location = new System.Drawing.Point(6, 13);
            this.existingFunctionLabel.Name = "existingFunctionLabel";
            this.existingFunctionLabel.Size = new System.Drawing.Size(48, 13);
            this.existingFunctionLabel.TabIndex = 18;
            this.existingFunctionLabel.Text = "Function";
            // 
            // existingProcRadioButton
            // 
            this.existingProcRadioButton.AutoSize = true;
            this.existingProcRadioButton.Location = new System.Drawing.Point(12, 262);
            this.existingProcRadioButton.Name = "existingProcRadioButton";
            this.existingProcRadioButton.Size = new System.Drawing.Size(155, 17);
            this.existingProcRadioButton.TabIndex = 20;
            this.existingProcRadioButton.Text = "Execute Existing Procedure";
            this.existingProcRadioButton.UseVisualStyleBackColor = true;
            this.existingProcRadioButton.CheckedChanged += new System.EventHandler(this.existingProcRadioButton_CheckedChanged);
            // 
            // existingProcGroupBox
            // 
            this.existingProcGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.existingProcGroupBox.Controls.Add(this.existingProcParamField);
            this.existingProcGroupBox.Controls.Add(this.procedureParametersLabel);
            this.existingProcGroupBox.Controls.Add(this.existingProcComboBox);
            this.existingProcGroupBox.Controls.Add(this.procedureLabel);
            this.existingProcGroupBox.Location = new System.Drawing.Point(7, 280);
            this.existingProcGroupBox.Name = "existingProcGroupBox";
            this.existingProcGroupBox.Size = new System.Drawing.Size(794, 236);
            this.existingProcGroupBox.TabIndex = 19;
            this.existingProcGroupBox.TabStop = false;
            // 
            // existingProcParamField
            // 
            this.existingProcParamField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.existingProcParamField.AutoScroll = true;
            this.existingProcParamField.Location = new System.Drawing.Point(6, 69);
            this.existingProcParamField.Name = "existingProcParamField";
            this.existingProcParamField.Size = new System.Drawing.Size(782, 161);
            this.existingProcParamField.TabIndex = 21;
            // 
            // procedureParametersLabel
            // 
            this.procedureParametersLabel.AutoSize = true;
            this.procedureParametersLabel.Location = new System.Drawing.Point(6, 53);
            this.procedureParametersLabel.Name = "procedureParametersLabel";
            this.procedureParametersLabel.Size = new System.Drawing.Size(112, 13);
            this.procedureParametersLabel.TabIndex = 20;
            this.procedureParametersLabel.Text = "Procedure Parameters";
            // 
            // existingProcComboBox
            // 
            this.existingProcComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.existingProcComboBox.FormattingEnabled = true;
            this.existingProcComboBox.Location = new System.Drawing.Point(6, 29);
            this.existingProcComboBox.Name = "existingProcComboBox";
            this.existingProcComboBox.Size = new System.Drawing.Size(782, 21);
            this.existingProcComboBox.TabIndex = 19;
            this.existingProcComboBox.SelectedIndexChanged += new System.EventHandler(this.existingProcComboBox_SelectedIndexChanged);
            // 
            // procedureLabel
            // 
            this.procedureLabel.AutoSize = true;
            this.procedureLabel.Location = new System.Drawing.Point(6, 13);
            this.procedureLabel.Name = "procedureLabel";
            this.procedureLabel.Size = new System.Drawing.Size(56, 13);
            this.procedureLabel.TabIndex = 18;
            this.procedureLabel.Text = "Procedure";
            // 
            // existingQueryRadioButton
            // 
            this.existingQueryRadioButton.AutoSize = true;
            this.existingQueryRadioButton.Checked = true;
            this.existingQueryRadioButton.Location = new System.Drawing.Point(12, 7);
            this.existingQueryRadioButton.Name = "existingQueryRadioButton";
            this.existingQueryRadioButton.Size = new System.Drawing.Size(134, 17);
            this.existingQueryRadioButton.TabIndex = 19;
            this.existingQueryRadioButton.TabStop = true;
            this.existingQueryRadioButton.Text = "Execute Existing Query";
            this.existingQueryRadioButton.UseVisualStyleBackColor = true;
            this.existingQueryRadioButton.CheckedChanged += new System.EventHandler(this.existingQueryRadioButton_CheckedChanged);
            // 
            // existingQueryGroupBox
            // 
            this.existingQueryGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.existingQueryGroupBox.Controls.Add(this.existingQueryDescrBox);
            this.existingQueryGroupBox.Controls.Add(this.queryLabel);
            this.existingQueryGroupBox.Controls.Add(this.label2);
            this.existingQueryGroupBox.Controls.Add(this.queryComboBox);
            this.existingQueryGroupBox.Location = new System.Drawing.Point(6, 20);
            this.existingQueryGroupBox.Name = "existingQueryGroupBox";
            this.existingQueryGroupBox.Size = new System.Drawing.Size(795, 236);
            this.existingQueryGroupBox.TabIndex = 18;
            this.existingQueryGroupBox.TabStop = false;
            // 
            // existingQueryDescrBox
            // 
            this.existingQueryDescrBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.existingQueryDescrBox.FormattingEnabled = true;
            this.existingQueryDescrBox.Location = new System.Drawing.Point(6, 72);
            this.existingQueryDescrBox.Name = "existingQueryDescrBox";
            this.existingQueryDescrBox.Size = new System.Drawing.Size(783, 160);
            this.existingQueryDescrBox.TabIndex = 22;
            // 
            // queryLabel
            // 
            this.queryLabel.AutoSize = true;
            this.queryLabel.Location = new System.Drawing.Point(6, 16);
            this.queryLabel.Name = "queryLabel";
            this.queryLabel.Size = new System.Drawing.Size(35, 13);
            this.queryLabel.TabIndex = 20;
            this.queryLabel.Text = "Query";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Description";
            // 
            // queryComboBox
            // 
            this.queryComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.queryComboBox.FormattingEnabled = true;
            this.queryComboBox.Location = new System.Drawing.Point(6, 32);
            this.queryComboBox.MinimumSize = new System.Drawing.Size(150, 0);
            this.queryComboBox.Name = "queryComboBox";
            this.queryComboBox.Size = new System.Drawing.Size(783, 21);
            this.queryComboBox.TabIndex = 19;
            this.queryComboBox.SelectedIndexChanged += new System.EventHandler(this.queryComboBox_SelectedIndexChanged_1);
            // 
            // SQLPage
            // 
            this.SQLPage.AutoScroll = true;
            this.SQLPage.Controls.Add(this.SQLTextBox);
            this.SQLPage.Controls.Add(this.label3);
            this.SQLPage.Location = new System.Drawing.Point(4, 22);
            this.SQLPage.Name = "SQLPage";
            this.SQLPage.Padding = new System.Windows.Forms.Padding(3);
            this.SQLPage.Size = new System.Drawing.Size(814, 435);
            this.SQLPage.TabIndex = 2;
            this.SQLPage.Text = "SQL";
            this.SQLPage.UseVisualStyleBackColor = true;
            // 
            // SQLTextBox
            // 
            this.SQLTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SQLTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SQLTextBox.Location = new System.Drawing.Point(6, 19);
            this.SQLTextBox.Name = "SQLTextBox";
            this.SQLTextBox.ShortcutsEnabled = false;
            this.SQLTextBox.Size = new System.Drawing.Size(802, 398);
            this.SQLTextBox.TabIndex = 2;
            this.SQLTextBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "SQL Query";
            // 
            // tempLabel
            // 
            this.tempLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tempLabel.AutoSize = true;
            this.tempLabel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tempLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tempLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.tempLabel.Location = new System.Drawing.Point(300, 636);
            this.tempLabel.Name = "tempLabel";
            this.tempLabel.Size = new System.Drawing.Size(248, 16);
            this.tempLabel.TabIndex = 19;
            this.tempLabel.Text = "Your query results will be displayed here";
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Location = new System.Drawing.Point(760, 479);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 20;
            this.clearButton.Text = "Clear Table";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(12, 480);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 21;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(94, 480);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 22;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(848, 789);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.tempLabel);
            this.Controls.Add(this.mainTabWindow);
            this.Controls.Add(this.resultDataGridView);
            this.Controls.Add(this.executeButton);
            this.MinimumSize = new System.Drawing.Size(300, 400);
            this.Name = "Form1";
            this.Text = "Access Beholder";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).EndInit();
            this.mainTabWindow.ResumeLayout(false);
            this.customPage.ResumeLayout(false);
            this.customPage.PerformLayout();
            this.newControllersSet.ResumeLayout(false);
            this.newControllersSetSplitContainer.Panel2.ResumeLayout(false);
            this.newControllersSetSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newControllersSetSplitContainer)).EndInit();
            this.newControllersSetSplitContainer.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.existingPage.ResumeLayout(false);
            this.existingPage.PerformLayout();
            this.existingFunctionGroupBox.ResumeLayout(false);
            this.existingFunctionGroupBox.PerformLayout();
            this.existingProcGroupBox.ResumeLayout(false);
            this.existingProcGroupBox.PerformLayout();
            this.existingQueryGroupBox.ResumeLayout(false);
            this.existingQueryGroupBox.PerformLayout();
            this.SQLPage.ResumeLayout(false);
            this.SQLPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.CheckedListBox tablesCheckedListBox;
        private System.Windows.Forms.CheckedListBox fieldsCheckedListBox;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.DataGridView resultDataGridView;
        private System.Windows.Forms.TabControl mainTabWindow;
        private System.Windows.Forms.TabPage customPage;
        private System.Windows.Forms.TabPage existingPage;
        private System.Windows.Forms.TabPage SQLPage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox SQLTextBox;
        private System.Windows.Forms.Panel newControllersSet;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer newControllersSetSplitContainer;
        private System.Windows.Forms.RadioButton existingProcRadioButton;
        private System.Windows.Forms.GroupBox existingProcGroupBox;
        private System.Windows.Forms.Panel existingProcParamField;
        private System.Windows.Forms.Label procedureParametersLabel;
        private System.Windows.Forms.ComboBox existingProcComboBox;
        private System.Windows.Forms.Label procedureLabel;
        private System.Windows.Forms.RadioButton existingQueryRadioButton;
        private System.Windows.Forms.GroupBox existingQueryGroupBox;
        private System.Windows.Forms.ListBox existingQueryDescrBox;
        private System.Windows.Forms.Label queryLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox queryComboBox;
        private System.Windows.Forms.RadioButton existingFunctionRadioButton;
        private System.Windows.Forms.GroupBox existingFunctionGroupBox;
        private System.Windows.Forms.Panel existingFunctionParamField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox existingFunctionComboBox;
        private System.Windows.Forms.Label existingFunctionLabel;
        private System.Windows.Forms.RichTextBox queryConditionsRichTextBox;
        private System.Windows.Forms.Label conditionsSetLabel;
        private System.Windows.Forms.ComboBox operatorsConditionsComboBox;
        private System.Windows.Forms.ComboBox comparatorConditionsComboBox;
        private System.Windows.Forms.ComboBox fieldsConditionsComboBox;
        private System.Windows.Forms.ComboBox caseConditionsComboBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox aggregateConditionsComboBox;
        private System.Windows.Forms.ComboBox actionsConditionsComboBox;
        private System.Windows.Forms.Label tempLabel;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button saveButton;
    }
}

