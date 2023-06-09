﻿namespace SumoPoolUI
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
            cboJour = new ComboBox();
            lblIdPool = new Label();
            btnCalculerScore = new Button();
            fileDialogPool = new OpenFileDialog();
            menuStrip1 = new MenuStrip();
            Menu = new ToolStripMenuItem();
            ouvrirUnPoolToolStripMenuItem = new ToolStripMenuItem();
            listScore = new ListView();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.Location = new Point(105, 57);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(38, 15);
            lblFileName.TabIndex = 0;
            lblFileName.Text = "label1";
            // 
            // cboJour
            // 
            cboJour.FormattingEnabled = true;
            cboJour.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" });
            cboJour.Location = new Point(342, 49);
            cboJour.Name = "cboJour";
            cboJour.Size = new Size(121, 23);
            cboJour.TabIndex = 2;
            // 
            // lblIdPool
            // 
            lblIdPool.AutoSize = true;
            lblIdPool.Location = new Point(52, 57);
            lblIdPool.Name = "lblIdPool";
            lblIdPool.Size = new Size(34, 15);
            lblIdPool.TabIndex = 4;
            lblIdPool.Text = "Pool:";
            // 
            // btnCalculerScore
            // 
            btnCalculerScore.Location = new Point(163, 49);
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
            Menu.DropDownItems.AddRange(new ToolStripItem[] { ouvrirUnPoolToolStripMenuItem });
            Menu.Name = "Menu";
            Menu.Size = new Size(50, 20);
            Menu.Text = "Menu";
            // 
            // ouvrirUnPoolToolStripMenuItem
            // 
            ouvrirUnPoolToolStripMenuItem.Name = "ouvrirUnPoolToolStripMenuItem";
            ouvrirUnPoolToolStripMenuItem.Size = new Size(151, 22);
            ouvrirUnPoolToolStripMenuItem.Text = "Ouvrir un pool";
            ouvrirUnPoolToolStripMenuItem.Click += ouvrirUnPoolToolStripMenuItem_Click;
            // 
            // listScore
            // 
            listScore.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listScore.Location = new Point(22, 75);
            listScore.Name = "listScore";
            listScore.Size = new Size(766, 370);
            listScore.TabIndex = 7;
            listScore.UseCompatibleStateImageBehavior = false;
            // 
            // frmManagePool
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 473);
            Controls.Add(listScore);
            Controls.Add(btnCalculerScore);
            Controls.Add(lblIdPool);
            Controls.Add(cboJour);
            Controls.Add(lblFileName);
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

        private Label lblFileName;
        private ComboBox cboJour;
        private Label lblIdPool;
        private Button btnCalculerScore;
        private OpenFileDialog fileDialogPool;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem Menu;
        private ToolStripMenuItem ouvrirUnPoolToolStripMenuItem;
        private ListView listScore;
    }
}