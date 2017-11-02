namespace Lession_20
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
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            this.lvListServiceRunning = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvListServiceStopped = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReFresh = new System.Windows.Forms.Button();
            this.btnStopService = new System.Windows.Forms.Button();
            this.btnGetListService = new System.Windows.Forms.Button();
            this.btnStartService = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvListServiceRunning
            // 
            this.lvListServiceRunning.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvListServiceRunning.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.lvListServiceRunning.Location = new System.Drawing.Point(18, 38);
            this.lvListServiceRunning.Name = "lvListServiceRunning";
            this.lvListServiceRunning.Size = new System.Drawing.Size(267, 428);
            this.lvListServiceRunning.TabIndex = 0;
            this.lvListServiceRunning.UseCompatibleStateImageBehavior = false;
            this.lvListServiceRunning.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Service Name";
            this.columnHeader1.Width = 257;
            // 
            // lvListServiceStopped
            // 
            this.lvListServiceStopped.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvListServiceStopped.Location = new System.Drawing.Point(325, 38);
            this.lvListServiceStopped.Name = "lvListServiceStopped";
            this.lvListServiceStopped.Size = new System.Drawing.Size(267, 428);
            this.lvListServiceStopped.TabIndex = 1;
            this.lvListServiceStopped.UseCompatibleStateImageBehavior = false;
            this.lvListServiceStopped.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Service Name";
            this.columnHeader2.Width = 255;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "List Service Running";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(372, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "List Service Stopped";
            // 
            // btnReFresh
            // 
            this.btnReFresh.Location = new System.Drawing.Point(272, 12);
            this.btnReFresh.Name = "btnReFresh";
            this.btnReFresh.Size = new System.Drawing.Size(75, 23);
            this.btnReFresh.TabIndex = 4;
            this.btnReFresh.Text = "ReFresh";
            this.btnReFresh.UseVisualStyleBackColor = true;
            this.btnReFresh.Click += new System.EventHandler(this.btnReFresh_Click);
            // 
            // btnStopService
            // 
            this.btnStopService.Location = new System.Drawing.Point(78, 472);
            this.btnStopService.Name = "btnStopService";
            this.btnStopService.Size = new System.Drawing.Size(126, 23);
            this.btnStopService.TabIndex = 5;
            this.btnStopService.Text = "Stop Service";
            this.btnStopService.UseVisualStyleBackColor = true;
            this.btnStopService.Click += new System.EventHandler(this.btnStopService_Click);
            // 
            // btnGetListService
            // 
            this.btnGetListService.Location = new System.Drawing.Point(247, 472);
            this.btnGetListService.Name = "btnGetListService";
            this.btnGetListService.Size = new System.Drawing.Size(126, 23);
            this.btnGetListService.TabIndex = 6;
            this.btnGetListService.Text = "Get List Service";
            this.btnGetListService.UseVisualStyleBackColor = true;
            // 
            // btnStartService
            // 
            this.btnStartService.Location = new System.Drawing.Point(404, 472);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(126, 23);
            this.btnStartService.TabIndex = 7;
            this.btnStartService.Text = "Start Service";
            this.btnStartService.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 510);
            this.Controls.Add(this.btnStartService);
            this.Controls.Add(this.btnGetListService);
            this.Controls.Add(this.btnStopService);
            this.Controls.Add(this.btnReFresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvListServiceStopped);
            this.Controls.Add(this.lvListServiceRunning);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvListServiceRunning;
        private System.Windows.Forms.ListView lvListServiceStopped;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReFresh;
        private System.Windows.Forms.Button btnStopService;
        private System.Windows.Forms.Button btnGetListService;
        private System.Windows.Forms.Button btnStartService;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

