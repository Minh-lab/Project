namespace QuanLiSinhVienNhom4
{
    partial class timkiemlop
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbtimkiem = new System.Windows.Forms.ComboBox();
            this.lbltimkiem = new System.Windows.Forms.Label();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(60, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm kiếm theo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbtimkiem
            // 
            this.cmbtimkiem.FormattingEnabled = true;
            this.cmbtimkiem.Items.AddRange(new object[] {
            "Mã Lớp",
            "Mã Khoa",
            "Mã GVCN",
            "Tên Lớp",
            "Tên GVCN",
            "Tên Khoa"});
            this.cmbtimkiem.Location = new System.Drawing.Point(243, 38);
            this.cmbtimkiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbtimkiem.Name = "cmbtimkiem";
            this.cmbtimkiem.Size = new System.Drawing.Size(433, 33);
            this.cmbtimkiem.TabIndex = 1;
            this.cmbtimkiem.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.cmbtimkiem.TextChanged += new System.EventHandler(this.cmbtimkiem_TextChanged);
            // 
            // lbltimkiem
            // 
            this.lbltimkiem.Location = new System.Drawing.Point(60, 136);
            this.lbltimkiem.Name = "lbltimkiem";
            this.lbltimkiem.Size = new System.Drawing.Size(153, 20);
            this.lbltimkiem.TabIndex = 2;
            this.lbltimkiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(243, 131);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(433, 33);
            this.txttimkiem.TabIndex = 3;
            this.txttimkiem.Visible = false;
            this.txttimkiem.TextChanged += new System.EventHandler(this.txttimkiem_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(572, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 46);
            this.button1.TabIndex = 4;
            this.button1.Text = "Tìm kiếm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // timkiemlop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 289);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txttimkiem);
            this.Controls.Add(this.lbltimkiem);
            this.Controls.Add(this.cmbtimkiem);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "timkiemlop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm  lớp";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbtimkiem;
        private System.Windows.Forms.Label lbltimkiem;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}