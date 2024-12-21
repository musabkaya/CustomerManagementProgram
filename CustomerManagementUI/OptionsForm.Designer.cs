namespace CustomerManagementUI
{
    partial class OptionsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnBackHome;
        private System.Windows.Forms.Button btnToggleTheme;
        private System.Windows.Forms.Button btnAddTier;
        private System.Windows.Forms.Button btnRemoveTier;
        private System.Windows.Forms.Button btnEditTier;
        private System.Windows.Forms.ListBox listBoxTiers;
        private System.Windows.Forms.Label lblTiers;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnBackHome = new System.Windows.Forms.Button();
            this.btnToggleTheme = new System.Windows.Forms.Button();
            this.btnAddTier = new System.Windows.Forms.Button();
            this.btnRemoveTier = new System.Windows.Forms.Button();
            this.btnEditTier = new System.Windows.Forms.Button();
            this.listBoxTiers = new System.Windows.Forms.ListBox();
            this.lblTiers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBackHome
            // 
            this.btnBackHome.Location = new System.Drawing.Point(20, 20);
            this.btnBackHome.Name = "btnBackHome";
            this.btnBackHome.Size = new System.Drawing.Size(100, 30);
            this.btnBackHome.Text = "Back to Home";
            this.btnBackHome.UseVisualStyleBackColor = true;
            this.btnBackHome.Click += new System.EventHandler(this.btnBackHome_Click);
            // 
            // btnToggleTheme
            // 
            this.btnToggleTheme.Location = new System.Drawing.Point(140, 20);
            this.btnToggleTheme.Name = "btnToggleTheme";
            this.btnToggleTheme.Size = new System.Drawing.Size(120, 30);
            this.btnToggleTheme.Text = "Toggle Theme";
            this.btnToggleTheme.UseVisualStyleBackColor = true;
            this.btnToggleTheme.Click += new System.EventHandler(this.btnToggleTheme_Click);
            // 
            // lblTiers
            // 
            this.lblTiers.AutoSize = true;
            this.lblTiers.Location = new System.Drawing.Point(20, 70);
            this.lblTiers.Name = "lblTiers";
            this.lblTiers.Size = new System.Drawing.Size(95, 13);
            this.lblTiers.Text = "Tier Management";
            // 
            // listBoxTiers
            // 
            this.listBoxTiers.FormattingEnabled = true;
            this.listBoxTiers.Location = new System.Drawing.Point(20, 100);
            this.listBoxTiers.Name = "listBoxTiers";
            this.listBoxTiers.Size = new System.Drawing.Size(240, 95);
            // 
            // btnAddTier
            // 
            this.btnAddTier.Location = new System.Drawing.Point(20, 210);
            this.btnAddTier.Name = "btnAddTier";
            this.btnAddTier.Size = new System.Drawing.Size(75, 25);
            this.btnAddTier.Text = "Add Tier";
            this.btnAddTier.UseVisualStyleBackColor = true;
            this.btnAddTier.Click += new System.EventHandler(this.btnAddTier_Click);
            // 
            // btnRemoveTier
            // 
            this.btnRemoveTier.Location = new System.Drawing.Point(190, 210);
            this.btnRemoveTier.Name = "btnRemoveTier";
            this.btnRemoveTier.Size = new System.Drawing.Size(75, 25);
            this.btnRemoveTier.Text = "Remove Tier";
            this.btnRemoveTier.UseVisualStyleBackColor = true;
            this.btnRemoveTier.Click += new System.EventHandler(this.btnRemoveTier_Click);
            // 
            // btnEditTier
            // 
            this.btnEditTier.Location = new System.Drawing.Point(105, 210);
            this.btnEditTier.Name = "btnEditTier";
            this.btnEditTier.Size = new System.Drawing.Size(75, 25);
            this.btnEditTier.Text = "Edit Tier";
            this.btnEditTier.UseVisualStyleBackColor = true;
            this.btnEditTier.Click += new System.EventHandler(this.btnEditTier_Click);
            // 
            // OptionsForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.btnBackHome);
            this.Controls.Add(this.btnToggleTheme);
            this.Controls.Add(this.lblTiers);
            this.Controls.Add(this.listBoxTiers);
            this.Controls.Add(this.btnAddTier);
            this.Controls.Add(this.btnEditTier);
            this.Controls.Add(this.btnRemoveTier);
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
