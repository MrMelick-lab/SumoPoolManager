namespace SumoPoolUI
{
    partial class frmManagePool
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
            lblFileName = new Label();
            GridPool = new DataGridView();
            cboJour = new ComboBox();
            lblIdPool = new Label();
            btnCalculerScore = new Button();
            ((System.ComponentModel.ISupportInitialize)GridPool).BeginInit();
            SuspendLayout();
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.Location = new Point(100, 30);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(38, 15);
            lblFileName.TabIndex = 0;
            lblFileName.Text = "label1";
            // 
            // GridPool
            // 
            GridPool.AllowUserToOrderColumns = true;
            GridPool.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridPool.Location = new Point(12, 51);
            GridPool.Name = "GridPool";
            GridPool.RowTemplate.Height = 25;
            GridPool.Size = new Size(771, 387);
            GridPool.TabIndex = 1;
            // 
            // cboJour
            // 
            cboJour.FormattingEnabled = true;
            cboJour.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" });
            cboJour.Location = new Point(337, 22);
            cboJour.Name = "cboJour";
            cboJour.Size = new Size(121, 23);
            cboJour.TabIndex = 2;
            cboJour.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // lblIdPool
            // 
            lblIdPool.AutoSize = true;
            lblIdPool.Location = new Point(47, 30);
            lblIdPool.Name = "lblIdPool";
            lblIdPool.Size = new Size(34, 15);
            lblIdPool.TabIndex = 4;
            lblIdPool.Text = "Pool:";
            // 
            // btnCalculerScore
            // 
            btnCalculerScore.Location = new Point(158, 22);
            btnCalculerScore.Name = "btnCalculerScore";
            btnCalculerScore.Size = new Size(173, 23);
            btnCalculerScore.TabIndex = 5;
            btnCalculerScore.Text = "Calculer scores pour le jour";
            btnCalculerScore.UseVisualStyleBackColor = true;
            // 
            // frmManagePool
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCalculerScore);
            Controls.Add(lblIdPool);
            Controls.Add(cboJour);
            Controls.Add(GridPool);
            Controls.Add(lblFileName);
            Name = "frmManagePool";
            Text = "frmManagePool";
            Load += frmManagePool_Load;
            ((System.ComponentModel.ISupportInitialize)GridPool).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFileName;
        private DataGridView GridPool;
        private ComboBox cboJour;
        private Label lblIdPool;
        private Button btnCalculerScore;
    }
}