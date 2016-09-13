namespace MSWordFileRenamer
{
    partial class frmMain
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
            this.lbRenameResults = new System.Windows.Forms.ListBox();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.lblFolderPath = new System.Windows.Forms.Label();
            this.lblRenameResults = new System.Windows.Forms.Label();
            this.btnRename = new System.Windows.Forms.Button();
            this.lbFileList = new System.Windows.Forms.ListBox();
            this.lblFilesList = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCleanUp = new System.Windows.Forms.Button();
            this.btnOpenLog = new System.Windows.Forms.Button();
            this.btnNewTest = new System.Windows.Forms.Button();
            this.txtTestDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkCloseAfter = new System.Windows.Forms.CheckBox();
            this.chkRename = new System.Windows.Forms.CheckBox();
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lbRenameResults
            // 
            this.lbRenameResults.FormattingEnabled = true;
            this.lbRenameResults.Location = new System.Drawing.Point(430, 149);
            this.lbRenameResults.Name = "lbRenameResults";
            this.lbRenameResults.Size = new System.Drawing.Size(530, 329);
            this.lbRenameResults.TabIndex = 8;
            this.lbRenameResults.TabStop = false;
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(37, 39);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(467, 20);
            this.txtFolderPath.TabIndex = 2;
            // 
            // lblFolderPath
            // 
            this.lblFolderPath.AutoSize = true;
            this.lblFolderPath.Location = new System.Drawing.Point(34, 23);
            this.lblFolderPath.Name = "lblFolderPath";
            this.lblFolderPath.Size = new System.Drawing.Size(64, 13);
            this.lblFolderPath.TabIndex = 3;
            this.lblFolderPath.Text = "Folder Path:";
            // 
            // lblRenameResults
            // 
            this.lblRenameResults.AutoSize = true;
            this.lblRenameResults.Location = new System.Drawing.Point(427, 133);
            this.lblRenameResults.Name = "lblRenameResults";
            this.lblRenameResults.Size = new System.Drawing.Size(45, 13);
            this.lblRenameResults.TabIndex = 4;
            this.lblRenameResults.Text = "Results:";
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(276, 149);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(103, 23);
            this.btnRename.TabIndex = 1;
            this.btnRename.Text = "Process Files";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // lbFileList
            // 
            this.lbFileList.FormattingEnabled = true;
            this.lbFileList.Location = new System.Drawing.Point(37, 149);
            this.lbFileList.Name = "lbFileList";
            this.lbFileList.Size = new System.Drawing.Size(204, 329);
            this.lbFileList.TabIndex = 9;
            this.lbFileList.TabStop = false;
            // 
            // lblFilesList
            // 
            this.lblFilesList.AutoSize = true;
            this.lblFilesList.Location = new System.Drawing.Point(34, 133);
            this.lblFilesList.Name = "lblFilesList";
            this.lblFilesList.Size = new System.Drawing.Size(42, 13);
            this.lblFilesList.TabIndex = 7;
            this.lblFilesList.Text = "File List";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(510, 39);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCleanUp
            // 
            this.btnCleanUp.Location = new System.Drawing.Point(276, 424);
            this.btnCleanUp.Name = "btnCleanUp";
            this.btnCleanUp.Size = new System.Drawing.Size(75, 23);
            this.btnCleanUp.TabIndex = 2;
            this.btnCleanUp.Text = "Clean Up";
            this.btnCleanUp.UseVisualStyleBackColor = true;
            this.btnCleanUp.Click += new System.EventHandler(this.btnCleanUp_Click);
            // 
            // btnOpenLog
            // 
            this.btnOpenLog.Location = new System.Drawing.Point(276, 453);
            this.btnOpenLog.Name = "btnOpenLog";
            this.btnOpenLog.Size = new System.Drawing.Size(75, 23);
            this.btnOpenLog.TabIndex = 10;
            this.btnOpenLog.Text = "Open Log";
            this.btnOpenLog.UseVisualStyleBackColor = true;
            this.btnOpenLog.Click += new System.EventHandler(this.btnOpenLog_Click);
            // 
            // btnNewTest
            // 
            this.btnNewTest.Location = new System.Drawing.Point(510, 90);
            this.btnNewTest.Name = "btnNewTest";
            this.btnNewTest.Size = new System.Drawing.Size(75, 23);
            this.btnNewTest.TabIndex = 12;
            this.btnNewTest.Text = "New Test";
            this.btnNewTest.UseVisualStyleBackColor = true;
            this.btnNewTest.Click += new System.EventHandler(this.btnNewTest_Click);
            // 
            // txtTestDesc
            // 
            this.txtTestDesc.Location = new System.Drawing.Point(37, 90);
            this.txtTestDesc.Name = "txtTestDesc";
            this.txtTestDesc.Size = new System.Drawing.Size(467, 20);
            this.txtTestDesc.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Test Description:";
            // 
            // chkCloseAfter
            // 
            this.chkCloseAfter.AutoSize = true;
            this.chkCloseAfter.Location = new System.Drawing.Point(276, 224);
            this.chkCloseAfter.Name = "chkCloseAfter";
            this.chkCloseAfter.Size = new System.Drawing.Size(52, 17);
            this.chkCloseAfter.TabIndex = 15;
            this.chkCloseAfter.Text = "Close";
            this.chkCloseAfter.UseVisualStyleBackColor = true;
            // 
            // chkRename
            // 
            this.chkRename.AutoSize = true;
            this.chkRename.Location = new System.Drawing.Point(276, 178);
            this.chkRename.Name = "chkRename";
            this.chkRename.Size = new System.Drawing.Size(66, 17);
            this.chkRename.TabIndex = 16;
            this.chkRename.Text = "Save As";
            this.chkRename.UseVisualStyleBackColor = true;
            // 
            // chkSave
            // 
            this.chkSave.AutoSize = true;
            this.chkSave.Location = new System.Drawing.Point(276, 201);
            this.chkSave.Name = "chkSave";
            this.chkSave.Size = new System.Drawing.Size(93, 17);
            this.chkSave.TabIndex = 17;
            this.chkSave.Text = "Edit and Save";
            this.chkSave.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 506);
            this.Controls.Add(this.chkSave);
            this.Controls.Add(this.chkRename);
            this.Controls.Add(this.chkCloseAfter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTestDesc);
            this.Controls.Add(this.btnNewTest);
            this.Controls.Add(this.btnOpenLog);
            this.Controls.Add(this.btnCleanUp);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lblFilesList);
            this.Controls.Add(this.lbFileList);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.lblRenameResults);
            this.Controls.Add(this.lblFolderPath);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.lbRenameResults);
            this.Name = "frmMain";
            this.Text = "Word File Tester";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbRenameResults;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Label lblFolderPath;
        private System.Windows.Forms.Label lblRenameResults;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.ListBox lbFileList;
        private System.Windows.Forms.Label lblFilesList;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCleanUp;
        private System.Windows.Forms.Button btnOpenLog;
        private System.Windows.Forms.Button btnNewTest;
        private System.Windows.Forms.TextBox txtTestDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkCloseAfter;
        private System.Windows.Forms.CheckBox chkRename;
        private System.Windows.Forms.CheckBox chkSave;
    }
}

