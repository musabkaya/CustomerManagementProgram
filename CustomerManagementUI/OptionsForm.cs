using System;
using System.Linq;
using System.Windows.Forms;
using CustomerManagementLibrary;
using System.Drawing;
using Microsoft.VisualBasic; // for Interaction.InputBox

namespace CustomerManagementUI
{
    public partial class OptionsForm : Form
    {
        private bool _isDarkMode = false;

        public OptionsForm()
        {
            InitializeComponent();
            LoadTiers();
        }

        private void LoadTiers()
        {
            listBoxTiers.Items.Clear();
            foreach (var kvp in Customer.TierList.OrderByDescending(t => t.Value))
            {
                listBoxTiers.Items.Add($"{kvp.Key} => {kvp.Value} orders");
            }
        }

        private void btnToggleTheme_Click(object sender, EventArgs e)
        {
            _isDarkMode = !_isDarkMode;
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            // Basic example
            if (_isDarkMode)
            {
                this.BackColor = Color.FromArgb(45, 45, 48);
                lblTiers.ForeColor = Color.White;
                listBoxTiers.BackColor = Color.FromArgb(60, 60, 60);
                listBoxTiers.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = SystemColors.Control;
                lblTiers.ForeColor = Color.Black;
                listBoxTiers.BackColor = SystemColors.Window;
                listBoxTiers.ForeColor = Color.Black;
            }
        }

        private void btnAddTier_Click(object sender, EventArgs e)
        {
            string tierName = Interaction.InputBox("Enter Tier Name:", "Add Tier", "Platinum");
            if (string.IsNullOrWhiteSpace(tierName)) return;

            string thresholdStr = Interaction.InputBox("Enter Order Threshold:", "Add Tier", "100");
            if (!int.TryParse(thresholdStr, out int threshold) || threshold < 0)
            {
                MessageBox.Show("Invalid threshold value.");
                return;
            }

            try
            {
                AppData.Manager.AddTier(tierName, threshold);
                LoadTiers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding tier: " + ex.Message);
            }
        }

        private void btnRemoveTier_Click(object sender, EventArgs e)
        {
            if (listBoxTiers.SelectedIndex < 0)
            {
                MessageBox.Show("Select a tier to remove.");
                return;
            }

            string selected = listBoxTiers.SelectedItem.ToString();
            string tierName = selected.Split(new string[] { " => " }, StringSplitOptions.None)[0];

            if (MessageBox.Show($"Remove tier '{tierName}'?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    AppData.Manager.RemoveTier(tierName);
                    LoadTiers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error removing tier: " + ex.Message);
                }
            }
        }

        private void btnEditTier_Click(object sender, EventArgs e)
        {
            if (listBoxTiers.SelectedIndex < 0)
            {
                MessageBox.Show("Select a tier to edit.");
                return;
            }

            string selected = listBoxTiers.SelectedItem.ToString();
            string tierName = selected.Split(new string[] { " => " }, StringSplitOptions.None)[0];

            string newThresholdStr = Interaction.InputBox("Enter new threshold:", "Edit Tier", "100");
            if (!int.TryParse(newThresholdStr, out int newThreshold) || newThreshold < 0)
            {
                MessageBox.Show("Invalid threshold value.");
                return;
            }

            try
            {
                AppData.Manager.EditTier(tierName, newThreshold);
                LoadTiers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error editing tier: " + ex.Message);
            }
        }

        private void btnBackHome_Click(object sender, EventArgs e)
        {
            var home = new HomePageForm();
            home.FormClosed += (s, args) => this.Show();
            home.Show();
            this.Hide();
        }
    }
}
