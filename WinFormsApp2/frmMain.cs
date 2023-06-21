using SumoPoolUI;

namespace WinFormsApp2
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnOuvrilPool_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var frmManagePool = new frmManagePool
                {
                    FilePath = fileDialog.FileName
                };
                frmManagePool.ShowDialog();
            }
        }
    }
}