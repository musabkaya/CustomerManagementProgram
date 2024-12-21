namespace CustomerManagementUI
{
    partial class HomePageForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTotalCustomers;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label lblAverageOrderValue;
        private System.Windows.Forms.Button btnCustomerManagement;
        private System.Windows.Forms.Button btnOptions;

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
            this.lblTotalCustomers = new System.Windows.Forms.Label();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.lblAverageOrderValue = new System.Windows.Forms.Label();
            this.btnCustomerManagement = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();

            this.SuspendLayout();
            // 
            // lblTotalCustomers
            // 
            this.lblTotalCustomers.AutoSize = true;
            this.lblTotalCustomers.Location = new System.Drawing.Point(20, 20);
            this.lblTotalCustomers.Name = "lblTotalCustomers";
            this.lblTotalCustomers.Size = new System.Drawing.Size(105, 13);
            this.lblTotalCustomers.Text = "Total Customers: 0";
            // 
            // lblTotalOrders
            // 
            this.lblTotalOrders.AutoSize = true;
            this.lblTotalOrders.Location = new System.Drawing.Point(20, 50);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(76, 13);
            this.lblTotalOrders.Text = "Total Orders: 0";
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.Location = new System.Drawing.Point(20, 80);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(74, 13);
            this.lblTotalSales.Text = "Total Sales: 0";
            // 
            // lblAverageOrderValue
            // 
            this.lblAverageOrderValue.AutoSize = true;
            this.lblAverageOrderValue.Location = new System.Drawing.Point(20, 110);
            this.lblAverageOrderValue.Name = "lblAverageOrderValue";
            this.lblAverageOrderValue.Size = new System.Drawing.Size(79, 13);
            this.lblAverageOrderValue.Text = "Average Order:";
            // 
            // btnCustomerManagement
            // 
            this.btnCustomerManagement.Location = new System.Drawing.Point(20, 160);
            this.btnCustomerManagement.Name = "btnCustomerManagement";
            this.btnCustomerManagement.Size = new System.Drawing.Size(75, 23);
            this.btnCustomerManagement.Text = "Customer";
            this.btnCustomerManagement.UseVisualStyleBackColor = true;
            this.btnCustomerManagement.Click += new System.EventHandler(this.btnCustomerManagement_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(110, 160);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(75, 23);
            this.btnOptions.Text = "Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // HomePageForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 220);
            this.Controls.Add(this.lblTotalCustomers);
            this.Controls.Add(this.lblTotalOrders);
            this.Controls.Add(this.lblTotalSales);
            this.Controls.Add(this.lblAverageOrderValue);
            this.Controls.Add(this.btnCustomerManagement);
            this.Controls.Add(this.btnOptions);
            this.Name = "HomePageForm";
            this.Text = "Home Page";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
