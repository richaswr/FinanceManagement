namespace FinanceManagementWinFormsUi
{
    partial class frmFinanceManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinanceManagement));
            this.btnGetConfigs = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnGridSelectAll = new System.Windows.Forms.Button();
            this.dgvBatches = new System.Windows.Forms.DataGridView();
            this.btnGetExisting = new System.Windows.Forms.Button();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dgvBatchErrors = new System.Windows.Forms.DataGridView();
            this.scConfigs = new System.Windows.Forms.SplitContainer();
            this.dgvConfigs = new System.Windows.Forms.DataGridView();
            this.scBatches = new System.Windows.Forms.SplitContainer();
            this.scBatchErrors = new System.Windows.Forms.SplitContainer();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.hideErrorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowErrors = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatchErrors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scConfigs)).BeginInit();
            this.scConfigs.Panel1.SuspendLayout();
            this.scConfigs.Panel2.SuspendLayout();
            this.scConfigs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scBatches)).BeginInit();
            this.scBatches.Panel1.SuspendLayout();
            this.scBatches.Panel2.SuspendLayout();
            this.scBatches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scBatchErrors)).BeginInit();
            this.scBatchErrors.Panel2.SuspendLayout();
            this.scBatchErrors.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetConfigs
            // 
            this.btnGetConfigs.Location = new System.Drawing.Point(3, 3);
            this.btnGetConfigs.Name = "btnGetConfigs";
            this.btnGetConfigs.Size = new System.Drawing.Size(163, 23);
            this.btnGetConfigs.TabIndex = 0;
            this.btnGetConfigs.Text = "Refresh";
            this.btnGetConfigs.UseVisualStyleBackColor = true;
            this.btnGetConfigs.Click += new System.EventHandler(this.btnGetConfigs_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(3, 61);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(163, 23);
            this.btnProcess.TabIndex = 3;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnGridSelectAll
            // 
            this.btnGridSelectAll.Location = new System.Drawing.Point(3, 32);
            this.btnGridSelectAll.Name = "btnGridSelectAll";
            this.btnGridSelectAll.Size = new System.Drawing.Size(163, 23);
            this.btnGridSelectAll.TabIndex = 2;
            this.btnGridSelectAll.Text = "Select All";
            this.btnGridSelectAll.UseVisualStyleBackColor = true;
            this.btnGridSelectAll.Click += new System.EventHandler(this.btnGridSelectAll_Click);
            // 
            // dgvBatches
            // 
            this.dgvBatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBatches.Location = new System.Drawing.Point(0, 0);
            this.dgvBatches.Name = "dgvBatches";
            this.dgvBatches.RowTemplate.Height = 24;
            this.dgvBatches.Size = new System.Drawing.Size(1193, 200);
            this.dgvBatches.TabIndex = 3;
            // 
            // btnGetExisting
            // 
            this.btnGetExisting.Location = new System.Drawing.Point(9, 44);
            this.btnGetExisting.Name = "btnGetExisting";
            this.btnGetExisting.Size = new System.Drawing.Size(163, 23);
            this.btnGetExisting.TabIndex = 4;
            this.btnGetExisting.Text = "Existing";
            this.btnGetExisting.UseVisualStyleBackColor = true;
            this.btnGetExisting.Click += new System.EventHandler(this.btnGetExisting_Click);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(9, 16);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(163, 22);
            this.dtpFromDate.TabIndex = 5;
            // 
            // dgvBatchErrors
            // 
            this.dgvBatchErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBatchErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBatchErrors.Location = new System.Drawing.Point(0, 0);
            this.dgvBatchErrors.Name = "dgvBatchErrors";
            this.dgvBatchErrors.RowTemplate.Height = 24;
            this.dgvBatchErrors.Size = new System.Drawing.Size(1193, 200);
            this.dgvBatchErrors.TabIndex = 0;
            // 
            // scConfigs
            // 
            this.scConfigs.Location = new System.Drawing.Point(0, 27);
            this.scConfigs.Name = "scConfigs";
            // 
            // scConfigs.Panel1
            // 
            this.scConfigs.Panel1.Controls.Add(this.btnProcess);
            this.scConfigs.Panel1.Controls.Add(this.btnGetConfigs);
            this.scConfigs.Panel1.Controls.Add(this.btnGridSelectAll);
            // 
            // scConfigs.Panel2
            // 
            this.scConfigs.Panel2.Controls.Add(this.dgvConfigs);
            this.scConfigs.Size = new System.Drawing.Size(1387, 200);
            this.scConfigs.SplitterDistance = 190;
            this.scConfigs.TabIndex = 6;
            // 
            // dgvConfigs
            // 
            this.dgvConfigs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConfigs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConfigs.Location = new System.Drawing.Point(0, 0);
            this.dgvConfigs.Name = "dgvConfigs";
            this.dgvConfigs.RowTemplate.Height = 24;
            this.dgvConfigs.Size = new System.Drawing.Size(1193, 200);
            this.dgvConfigs.TabIndex = 1;
            // 
            // scBatches
            // 
            this.scBatches.Location = new System.Drawing.Point(0, 233);
            this.scBatches.Name = "scBatches";
            // 
            // scBatches.Panel1
            // 
            this.scBatches.Panel1.Controls.Add(this.btnShowErrors);
            this.scBatches.Panel1.Controls.Add(this.btnGetExisting);
            this.scBatches.Panel1.Controls.Add(this.dtpFromDate);
            // 
            // scBatches.Panel2
            // 
            this.scBatches.Panel2.Controls.Add(this.dgvBatches);
            this.scBatches.Size = new System.Drawing.Size(1387, 200);
            this.scBatches.SplitterDistance = 190;
            this.scBatches.TabIndex = 7;
            // 
            // scBatchErrors
            // 
            this.scBatchErrors.Location = new System.Drawing.Point(0, 439);
            this.scBatchErrors.Name = "scBatchErrors";
            // 
            // scBatchErrors.Panel2
            // 
            this.scBatchErrors.Panel2.Controls.Add(this.dgvBatchErrors);
            this.scBatchErrors.Size = new System.Drawing.Size(1387, 200);
            this.scBatchErrors.SplitterDistance = 190;
            this.scBatchErrors.TabIndex = 8;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1387, 24);
            this.menuStrip.TabIndex = 9;
            this.menuStrip.Text = "menuStrip1";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1});
            this.statusStrip.Location = new System.Drawing.Point(0, 657);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1387, 26);
            this.statusStrip.TabIndex = 10;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideErrorsToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(39, 24);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // hideErrorsToolStripMenuItem
            // 
            this.hideErrorsToolStripMenuItem.Name = "hideErrorsToolStripMenuItem";
            this.hideErrorsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.hideErrorsToolStripMenuItem.Text = "Hide Errors";
            this.hideErrorsToolStripMenuItem.Click += new System.EventHandler(this.hideErrorsToolStripMenuItem_Click);
            // 
            // btnShowErrors
            // 
            this.btnShowErrors.Location = new System.Drawing.Point(12, 73);
            this.btnShowErrors.Name = "btnShowErrors";
            this.btnShowErrors.Size = new System.Drawing.Size(163, 23);
            this.btnShowErrors.TabIndex = 6;
            this.btnShowErrors.Text = "Show Errors";
            this.btnShowErrors.UseVisualStyleBackColor = true;
            this.btnShowErrors.Click += new System.EventHandler(this.btnShowErrors_Click);
            // 
            // frmFinanceManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 683);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.scBatchErrors);
            this.Controls.Add(this.scConfigs);
            this.Controls.Add(this.scBatches);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmFinanceManagement";
            this.Text = "Finance Management";
            this.Load += new System.EventHandler(this.frmFinanceManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBatchErrors)).EndInit();
            this.scConfigs.Panel1.ResumeLayout(false);
            this.scConfigs.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scConfigs)).EndInit();
            this.scConfigs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigs)).EndInit();
            this.scBatches.Panel1.ResumeLayout(false);
            this.scBatches.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scBatches)).EndInit();
            this.scBatches.ResumeLayout(false);
            this.scBatchErrors.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scBatchErrors)).EndInit();
            this.scBatchErrors.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetConfigs;
        private System.Windows.Forms.Button btnGridSelectAll;
        private System.Windows.Forms.DataGridView dgvBatches;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnGetExisting;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DataGridView dgvBatchErrors;
        private System.Windows.Forms.SplitContainer scConfigs;
        private System.Windows.Forms.DataGridView dgvConfigs;
        private System.Windows.Forms.SplitContainer scBatches;
        private System.Windows.Forms.SplitContainer scBatchErrors;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem hideErrorsToolStripMenuItem;
        private System.Windows.Forms.Button btnShowErrors;
    }
}

