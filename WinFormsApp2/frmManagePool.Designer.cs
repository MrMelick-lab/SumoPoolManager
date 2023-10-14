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
            components = new System.ComponentModel.Container();
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
            lblSectionBlesse = new Label();
            panel1 = new Panel();
            btnSupprimerBlesse = new Button();
            btnModifierBlesse = new Button();
            lstviewBlesse = new ListView();
            btnChargerListeBlesse = new Button();
            lblListeBlesse = new Label();
            btnSauvegarderBlesse = new Button();
            lblJourBlesse = new Label();
            lblRikishiBlesseEnter = new Label();
            cboJourSortieBlesse = new ComboBox();
            txtRikishiBlesse = new TextBox();
            btnEntrerBlesse = new Button();
            injuredRikishiBindingSource = new BindingSource(components);
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)injuredRikishiBindingSource).BeginInit();
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
            menuStrip1.Size = new Size(1277, 24);
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
            // lblSectionBlesse
            // 
            lblSectionBlesse.AutoSize = true;
            lblSectionBlesse.Location = new Point(3, 0);
            lblSectionBlesse.Name = "lblSectionBlesse";
            lblSectionBlesse.Size = new Size(80, 15);
            lblSectionBlesse.TabIndex = 11;
            lblSectionBlesse.Text = "section blessé";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSupprimerBlesse);
            panel1.Controls.Add(btnModifierBlesse);
            panel1.Controls.Add(lstviewBlesse);
            panel1.Controls.Add(btnChargerListeBlesse);
            panel1.Controls.Add(lblListeBlesse);
            panel1.Controls.Add(btnSauvegarderBlesse);
            panel1.Controls.Add(lblJourBlesse);
            panel1.Controls.Add(lblRikishiBlesseEnter);
            panel1.Controls.Add(cboJourSortieBlesse);
            panel1.Controls.Add(txtRikishiBlesse);
            panel1.Controls.Add(btnEntrerBlesse);
            panel1.Controls.Add(lblSectionBlesse);
            panel1.Location = new Point(794, 75);
            panel1.Name = "panel1";
            panel1.Size = new Size(471, 593);
            panel1.TabIndex = 12;
            // 
            // btnSupprimerBlesse
            // 
            btnSupprimerBlesse.Location = new Point(156, 56);
            btnSupprimerBlesse.Name = "btnSupprimerBlesse";
            btnSupprimerBlesse.Size = new Size(148, 23);
            btnSupprimerBlesse.TabIndex = 23;
            btnSupprimerBlesse.Text = "Supprimer un blessé";
            btnSupprimerBlesse.UseVisualStyleBackColor = true;
            btnSupprimerBlesse.Click += btnSupprimerBlesse_Click;
            // 
            // btnModifierBlesse
            // 
            btnModifierBlesse.Location = new Point(33, 55);
            btnModifierBlesse.Name = "btnModifierBlesse";
            btnModifierBlesse.Size = new Size(117, 23);
            btnModifierBlesse.TabIndex = 22;
            btnModifierBlesse.Text = "Modifier un blessé";
            btnModifierBlesse.UseVisualStyleBackColor = true;
            // 
            // lstviewBlesse
            // 
            lstviewBlesse.Location = new Point(31, 158);
            lstviewBlesse.MultiSelect = false;
            lstviewBlesse.Name = "lstviewBlesse";
            lstviewBlesse.Size = new Size(416, 432);
            lstviewBlesse.TabIndex = 21;
            lstviewBlesse.UseCompatibleStateImageBehavior = false;
            // 
            // btnChargerListeBlesse
            // 
            btnChargerListeBlesse.Location = new Point(31, 114);
            btnChargerListeBlesse.Name = "btnChargerListeBlesse";
            btnChargerListeBlesse.Size = new Size(416, 23);
            btnChargerListeBlesse.TabIndex = 20;
            btnChargerListeBlesse.Text = "Charger liste blessé";
            btnChargerListeBlesse.UseVisualStyleBackColor = true;
            // 
            // lblListeBlesse
            // 
            lblListeBlesse.AutoSize = true;
            lblListeBlesse.Location = new Point(192, 140);
            lblListeBlesse.Name = "lblListeBlesse";
            lblListeBlesse.Size = new Size(100, 15);
            lblListeBlesse.TabIndex = 19;
            lblListeBlesse.Text = "Liste des blessé(s)";
            // 
            // btnSauvegarderBlesse
            // 
            btnSauvegarderBlesse.Location = new Point(31, 85);
            btnSauvegarderBlesse.Name = "btnSauvegarderBlesse";
            btnSauvegarderBlesse.Size = new Size(418, 23);
            btnSauvegarderBlesse.TabIndex = 18;
            btnSauvegarderBlesse.Text = "Sauvegarder liste blessé";
            btnSauvegarderBlesse.UseVisualStyleBackColor = true;
            // 
            // lblJourBlesse
            // 
            lblJourBlesse.AutoSize = true;
            lblJourBlesse.Location = new Point(323, 9);
            lblJourBlesse.Name = "lblJourBlesse";
            lblJourBlesse.Size = new Size(105, 15);
            lblJourBlesse.TabIndex = 16;
            lblJourBlesse.Text = "Jour déclaré blessé";
            // 
            // lblRikishiBlesseEnter
            // 
            lblRikishiBlesseEnter.AutoSize = true;
            lblRikishiBlesseEnter.Location = new Point(212, 9);
            lblRikishiBlesseEnter.Name = "lblRikishiBlesseEnter";
            lblRikishiBlesseEnter.Size = new Size(34, 15);
            lblRikishiBlesseEnter.TabIndex = 15;
            lblRikishiBlesseEnter.Text = "Nom";
            // 
            // cboJourSortieBlesse
            // 
            cboJourSortieBlesse.FormattingEnabled = true;
            cboJourSortieBlesse.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" });
            cboJourSortieBlesse.Location = new Point(310, 28);
            cboJourSortieBlesse.Name = "cboJourSortieBlesse";
            cboJourSortieBlesse.Size = new Size(141, 23);
            cboJourSortieBlesse.TabIndex = 14;
            // 
            // txtRikishiBlesse
            // 
            txtRikishiBlesse.Location = new Point(148, 27);
            txtRikishiBlesse.Name = "txtRikishiBlesse";
            txtRikishiBlesse.Size = new Size(156, 23);
            txtRikishiBlesse.TabIndex = 13;
            // 
            // btnEntrerBlesse
            // 
            btnEntrerBlesse.Location = new Point(33, 26);
            btnEntrerBlesse.Name = "btnEntrerBlesse";
            btnEntrerBlesse.Size = new Size(109, 23);
            btnEntrerBlesse.TabIndex = 12;
            btnEntrerBlesse.Text = "Entrer un blessé";
            btnEntrerBlesse.UseVisualStyleBackColor = true;
            btnEntrerBlesse.Click += btnEntrerBlesse_Click;
            // 
            // injuredRikishiBindingSource
            // 
            injuredRikishiBindingSource.DataSource = typeof(SumoPoolManager.Models.InjuredRikishi);
            // 
            // frmManagePool
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1277, 680);
            Controls.Add(panel1);
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
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)injuredRikishiBindingSource).EndInit();
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
        private Label lblSectionBlesse;
        private Panel panel1;
        private Button btnEntrerBlesse;
        private TextBox txtRikishiBlesse;
        private Label lblJourBlesse;
        private Label lblRikishiBlesseEnter;
        private ComboBox cboJourSortieBlesse;
        private Button btnSauvegarderBlesse;
        private Button btnChargerListeBlesse;
        private Label lblListeBlesse;
        private BindingSource injuredRikishiBindingSource;
        private ListView lstviewBlesse;
        private Button btnModifierBlesse;
        private Button btnSupprimerBlesse;
    }
}