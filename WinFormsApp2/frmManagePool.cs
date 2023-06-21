using SumoPoolManager.Models;
using System.Text.Json;

namespace SumoPoolUI
{
    public partial class frmManagePool : Form
    {
        public string FilePath { get; set; } = string.Empty;
        public Pool? Pool { get; set; } = new();
        public frmManagePool()
        {
            InitializeComponent();
        }

        private void frmManagePool_Load(object sender, EventArgs e)
        {
            using var poolStream = File.OpenRead(FilePath);
            Pool = JsonSerializer.Deserialize<Pool>(poolStream);
            if (Pool != null)
            {
                lblFileName.Text = Pool.TimestampId;
                GridPool.DataSource = Pool.Participants;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
