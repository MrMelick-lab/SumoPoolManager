﻿using SumoPoolManager.Models;
using SumoPoolManager.Services;
using CsvHelper;
using System.Globalization;
using System.Text.RegularExpressions;
using CsvHelper.Configuration;

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
            listScore.Columns.Add("Rikishi", 550);
        }

        private async void btnCalculerScore_Click(object sender, EventArgs e)
        {
            var validationResult = Validation();
            if (!validationResult.IsValid())
            {
                MessageBox.Show(string.Join(Environment.NewLine, validationResult.Messages), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Cursor = Cursors.WaitCursor;
            lblCalculEnCours.Visible = true;
            Pool.TimestampId = txtPool.Text;
            var resultatsNotOrdrered = await ScoreCalculator.CalculateScoreForPoolUntilSelectedDay(
                Pool.Participants,
                Pool.TimestampId,
                Convert.ToInt16(cboJour.SelectedItem));
            var orderedResults = resultatsNotOrdrered.OrderByDescending(x => x.Score).ThenBy(x => x.Name).ToList();
            listScore.Items.Clear();
            var records = new List<Records>();
            foreach (var particiant in orderedResults)
            {
                AddItem(particiant.Name, particiant.Score, particiant.Rikishis);
                var listofRikishiNames = particiant.Rikishis.Select(r => r.NameAndScore);
                listofRikishiNames = listofRikishiNames.OrderBy(r => r);
                var rikishisNameAndScores = string.Join(", ", listofRikishiNames);
                records.Add(new() { Name = particiant.Name, Score = particiant.Score, RikihisNameAndScores = rikishisNameAndScores });
            }
            listScore.Refresh();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture);
            await using (StreamWriter writer = new(".\\resultatPool.csv"))
            await using (CsvWriter csv = new(writer, config))
            {
                csv.WriteRecords(records);
            }
            Cursor = Cursors.Default;
            lblCalculEnCours.Visible = false;

        }
        private void AddItem(string name, int score, List<Rikishi> rikishis)
        {
            var item = new ListViewItem(name);
            item.SubItems.Add(score.ToString());
            var listofRikishiNames = rikishis.Select(r => r.NameAndScore);
            listofRikishiNames = listofRikishiNames.OrderBy(r => r);
            item.SubItems.Add(string.Join(", ", listofRikishiNames));
            listScore.Items.Add(item);
        }

        private void ouvrirUnPoolCsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileDialogPool.ShowDialog() == DialogResult.OK)
            {
                using var poolStream = new StreamReader(fileDialogPool.FileName);
                using var csv = new CsvReader(poolStream, CultureInfo.InvariantCulture);
                var records = csv.GetRecords<CsvRecords>().ToList();
                Pool = new();
                listScore.Items.Clear();
                foreach (var record in records)
                {
                    var participant = new Participant
                    {
                        Name = record.PseudoTwitch,
                        Rikishis =
                        [
                            new() { Name = record.YokozunaOzeki},
                            new() { Name = record.Sekiwake},
                            new() { Name = record.KomusubiAndMaegashira1},
                            new() { Name = record.Maegashira2To4 },
                            new() { Name = record.Maegashira5To7},
                            new() { Name = record.Maegashira8To11 },
                            new() { Name= record.Maegashira12To17 }
                        ]
                    };
                    Pool.Participants.Add(participant);
                    AddItem(participant.Name, participant.Score, participant.Rikishis);
                    listScore.Refresh();
                }
            }
        }

        private ValidationResult Validation()
        {
            var result = new ValidationResult();
            if(!ValidPoolId().IsMatch(txtPool.Text))
                result.Messages.Add("Veuilez entrer un identifiant de pool valide soit annéjour genre 202309 pour le pool de sepemtre 2023");

            if (Pool == null || (!Pool.Participants.Any()))
                result.Messages.Add("Veuillez sélection un fichier csv qui contient au moins un participant");

            if(cboJour.SelectedItem is null)
                result.Messages.Add("Veuillez sélectionner un jour");

            return result;
        }

        [GeneratedRegex("^[0-9]{6}$")]
        private static partial Regex ValidPoolId();
    }
}
