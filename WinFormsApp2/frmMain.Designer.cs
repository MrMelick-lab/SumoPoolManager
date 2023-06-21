namespace WinFormsApp2
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnOuvrilPool = new Button();
            fileDialog = new OpenFileDialog();
            SuspendLayout();
            // 
            // btnOuvrilPool
            // 
            btnOuvrilPool.Location = new Point(18, 12);
            btnOuvrilPool.Name = "btnOuvrilPool";
            btnOuvrilPool.Size = new Size(75, 23);
            btnOuvrilPool.TabIndex = 0;
            btnOuvrilPool.Text = "ouvrir pool";
            btnOuvrilPool.UseVisualStyleBackColor = true;
            btnOuvrilPool.Click += btnOuvrilPool_Click;
            // 
            // fileDialog
            // 
            fileDialog.FileName = "fileDialog";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnOuvrilPool);
            Name = "frmMain";
            Text = "Sumo";
            ResumeLayout(false);
        }

        #endregion

        private Button btnOuvrilPool;
        private OpenFileDialog fileDialog;
    }
}