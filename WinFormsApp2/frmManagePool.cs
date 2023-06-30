using SumoPoolManager.Models;
using System.Text.Json;
using SumoPoolManager.Services;

namespace SumoPoolUI
{
    public partial class frmManagePool : Form
    {
        public Pool? Pool { get; set; } = new();

        private readonly IScoreCalculator ScoreCalculator;
        public frmManagePool(IScoreCalculator scoreCalculator)
        {
            InitializeComponent();
            ScoreCalculator = scoreCalculator;
            listScore.View = View.Details; // Display items in a grid
            listScore.Columns.Add("Name", 120);
            listScore.Columns.Add("Score", 50);
        }

        private async void btnCalculerScore_Click(object sender, EventArgs e)
        {
            var resultatsNotOrdrered = await ScoreCalculator.CalculateScoreForPoolUntilSelectedDay(
                Pool.Participants,
                Pool.TimestampId,
                Convert.ToInt16(cboJour.SelectedItem));
            var orderedResults = resultatsNotOrdrered.OrderByDescending(x => x.Score).ThenBy(x => x.Name).ToList();
            listScore.Items.Clear();
            foreach (var particiant in Pool.Participants)
            {
                AddItem(particiant.Name, particiant.Score);
            }
            listScore.Refresh();
        }

        private void ouvrirUnPoolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileDialogPool.ShowDialog() == DialogResult.OK)
            {
                using var poolStream = File.OpenRead(fileDialogPool.FileName);
                Pool = JsonSerializer.Deserialize<Pool>(poolStream);
                if (Pool != null)
                {
                    lblFileName.Text = Pool.TimestampId;
                    listScore.Items.Clear();
                    foreach (var particiant in Pool.Participants)
                    {
                        AddItem(particiant.Name, particiant.Score);
                    }
                    listScore.Refresh();
                }
            }
        }

        private void AddItem(string name, int score)
        {
            var item = new ListViewItem(name);
            item.SubItems.Add(score.ToString());
            listScore.Items.Add(item);
        }
    }
}
