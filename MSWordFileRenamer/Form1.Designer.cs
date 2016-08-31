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
            this.btnCloseAll = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbRenameResults
            // 
            this.lbRenameResults.FormattingEnabled = true;
            this.lbRenameResults.Location = new System.Drawing.Point(404, 149);
            this.lbRenameResults.Name = "lbRenameResults";
            this.lbRenameResults.Size = new System.Drawing.Size(293, 329);
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
            this.lblRenameResults.Location = new System.Drawing.Point(401, 133);
            this.lblRenameResults.Name = "lblRenameResults";
            this.lblRenameResults.Size = new System.Drawing.Size(88, 13);
            this.lblRenameResults.TabIndex = 4;
            this.lblRenameResults.Text = "Rename Results:";
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(276, 149);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 1;
            this.btnRename.Text = "Rename";
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
            this.btnCleanUp.Location = new System.Drawing.Point(276, 207);
            this.btnCleanUp.Name = "btnCleanUp";
            this.btnCleanUp.Size = new System.Drawing.Size(75, 23);
            this.btnCleanUp.TabIndex = 2;
            this.btnCleanUp.Text = "Clean Up";
            this.btnCleanUp.UseVisualStyleBackColor = true;
            this.btnCleanUp.Click += new System.EventHandler(this.btnCleanUp_Click);
            // 
            // btnCloseAll
            // 
            this.btnCloseAll.Location = new System.Drawing.Point(276, 178);
            this.btnCloseAll.Name = "btnCloseAll";
            this.btnCloseAll.Size = new System.Drawing.Size(75, 23);
            this.btnCloseAll.TabIndex = 2;
            this.btnCloseAll.Text = "Close All";
            this.btnCloseAll.UseVisualStyleBackColor = true;
            this.btnCloseAll.Click += new System.EventHandler(this.btnCloseAll_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(276, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Clean Up";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 506);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCloseAll);
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
            this.Text = "Word File Renamer";
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
        private System.Windows.Forms.Button btnCloseAll;
        private System.Windows.Forms.Button button1;
    }
}

