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
            cboJour = new ComboBox();
            lblIdPool = new Label();
            btnCalculerScore = new Button();
            fileDialogPool = new OpenFileDialog();
            menuStrip1 = new MenuStrip();
            Menu = new ToolStripMenuItem();
            ouvrirUnPoolCsvToolStripMenuItem = new ToolStripMenuItem();
            listScore = new ListView();
            txtPool = new TextBox();
            lblCalculEnCours = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // cboJour
            // 
            cboJour.FormattingEnabled = true;
            cboJour.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" });
            cboJour.Location = new Point(381, 46);
            cboJour.Name = "cboJour";
            cboJour.Size = new Size(121, 23);
            cboJour.TabIndex = 2;
            // 
            // lblIdPool
            // 
            lblIdPool.AutoSize = true;
            lblIdPool.Location = new Point(31, 57);
            lblIdPool.Name = "lblIdPool";
            lblIdPool.Size = new Size(34, 15);
            lblIdPool.TabIndex = 4;
            lblIdPool.Text = "Pool:";
            // 
            // btnCalculerScore
            // 
            btnCalculerScore.Location = new Point(202, 46);
            btnCalculerScore.Name = "btnCalculerScore";
            btnCalculerScore.Size = new Size(173, 23);
            btnCalculerScore.TabIndex = 5;
            btnCalculerScore.Text = "Calculer scores pour le jour";
            btnCalculerScore.UseVisualStyleBackColor = true;
            btnCalculerScore.Click += btnCalculerScore_Click;
            // 
            // fileDialogPool
            // 
            fileDialogPool.FileName = "fileDialogPool";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { Menu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // Menu
            // 
            Menu.DropDownItems.AddRange(new ToolStripItem[] { ouvrirUnPoolCsvToolStripMenuItem });
            Menu.Name = "Menu";
            Menu.Size = new Size(50, 20);
            Menu.Text = "Menu";
            // 
            // ouvrirUnPoolCsvToolStripMenuItem
            // 
            ouvrirUnPoolCsvToolStripMenuItem.Name = "ouvrirUnPoolCsvToolStripMenuItem";
            ouvrirUnPoolCsvToolStripMenuItem.Size = new Size(171, 22);
            ouvrirUnPoolCsvToolStripMenuItem.Text = "Ouvrir un pool csv";
            ouvrirUnPoolCsvToolStripMenuItem.Click += ouvrirUnPoolCsvToolStripMenuItem_Click;
            // 
            // listScore
            // 
            listScore.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listScore.Location = new Point(22, 75);
            listScore.Name = "listScore";
            listScore.Size = new Size(766, 593);
            listScore.TabIndex = 7;
            listScore.UseCompatibleStateImageBehavior = false;
            // 
            // txtPool
            // 
            txtPool.Location = new Point(71, 49);
            txtPool.Name = "txtPool";
            txtPool.Size = new Size(116, 23);
            txtPool.TabIndex = 8;
            // 
            // lblCalculEnCours
            // 
            lblCalculEnCours.AutoSize = true;
            lblCalculEnCours.Location = new Point(230, 24);
            lblCalculEnCours.Name = "lblCalculEnCours";
            lblCalculEnCours.Size = new Size(145, 15);
            lblCalculEnCours.TabIndex = 9;
            lblCalculEnCours.Text = "Calcul du score en cours...";
            lblCalculEnCours.Visible = false;
            // 
            // frmManagePool
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 680);
            Controls.Add(lblCalculEnCours);
            Controls.Add(txtPool);
            Controls.Add(listScore);
            Controls.Add(btnCalculerScore);
            Controls.Add(lblIdPool);
            Controls.Add(cboJour);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmManagePool";
            Text = "Calculateur de pool";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cboJour;
        private Label lblIdPool;
        private Button btnCalculerScore;
        private OpenFileDialog fileDialogPool;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem Menu;
        private ListView listScore;
        private ToolStripMenuItem ouvrirUnPoolCsvToolStripMenuItem;
        private TextBox txtPool;
        private Label lblCalculEnCours;
    }
}