namespace Client
{
    partial class Client
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSQL = new System.Windows.Forms.TextBox();
            this.btnRunSQL = new System.Windows.Forms.Button();
            this.dgvDispay = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispay)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDispay);
            this.panel1.Controls.Add(this.btnRunSQL);
            this.panel1.Controls.Add(this.txtSQL);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 388);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the select command";
            // 
            // txtSQL
            // 
            this.txtSQL.Location = new System.Drawing.Point(16, 34);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(371, 29);
            this.txtSQL.TabIndex = 1;
            // 
            // btnRunSQL
            // 
            this.btnRunSQL.Location = new System.Drawing.Point(402, 34);
            this.btnRunSQL.Name = "btnRunSQL";
            this.btnRunSQL.Size = new System.Drawing.Size(114, 29);
            this.btnRunSQL.TabIndex = 2;
            this.btnRunSQL.Text = "Run SQL";
            this.btnRunSQL.UseVisualStyleBackColor = true;
            this.btnRunSQL.Click += new System.EventHandler(this.btnRunSQL_Click);
            // 
            // dgvDispay
            // 
            this.dgvDispay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDispay.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDispay.Location = new System.Drawing.Point(0, 91);
            this.dgvDispay.Name = "dgvDispay";
            this.dgvDispay.Size = new System.Drawing.Size(528, 297);
            this.dgvDispay.TabIndex = 3;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 388);
            this.Controls.Add(this.panel1);
            this.Name = "Client";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Client_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRunSQL;
        private System.Windows.Forms.TextBox txtSQL;
        private System.Windows.Forms.DataGridView dgvDispay;
    }
}

