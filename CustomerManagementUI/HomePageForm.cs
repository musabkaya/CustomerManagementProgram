using System;
using System.Linq;
using System.Windows.Forms;
using CustomerManagementLibrary;

namespace CustomerManagementUI
{
    public partial class HomePageForm : Form
    {
        public HomePageForm()
        {
            InitializeComponent();
            UpdateMetrics();
        }

        private void UpdateMetrics()
        {
            var customers = AppData.Manager.Customers;  // same instance as MainForm/OptionsForm

            if (customers.Count == 0)
            {
                lblTotalCustomers.Text = "No Customer Data Available";
                lblTotalOrders.Text = "";
                lblTotalSales.Text = "";
                lblAverageOrderValue.Text = "";
            }
            else
            {
                lblTotalCustomers.Text = $"Total Customers: {customers.Count}";
                lblTotalOrders.Text = $"Total Orders: {customers.Sum(c => c.OrderCount)}";
                lblTotalSales.Text = $"Total Sales: ${customers.Sum(c => c.TotalSales):F2}";

                double avgOrderValue = customers.Average(c => c.TotalSales / c.OrderCount);
                lblAverageOrderValue.Text = $"Average Order: ${avgOrderValue:F2}";
            }
        }

        private void btnCustomerManagement_Click(object sender, EventArgs e)
        {
            var mainForm = new MainForm();
            mainForm.FormClosed += (s, args) => this.Show();
            mainForm.Show();
            this.Hide();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            var optionsForm = new OptionsForm();
            optionsForm.FormClosed += (s, args) =>
            {
                // When user closes OptionsForm, re-show the HomePage and refresh metrics
                this.Show();
                UpdateMetrics();
            };
            optionsForm.Show();
            this.Hide();
        }
    }
}
