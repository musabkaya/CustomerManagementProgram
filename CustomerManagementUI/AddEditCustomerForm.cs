using System;
using System.Windows.Forms;
using CustomerManagementLibrary;

namespace CustomerManagementUI
{
    public partial class AddEditCustomerForm : Form
    {
        public AddEditCustomerForm()
        {
            InitializeComponent();
        }

        public AddEditCustomerForm(Customer existingCustomer) : this()
        {
            txtFirstName.Text = existingCustomer.FirstName;
            txtLastName.Text = existingCustomer.LastName;
            txtOrderCount.Text = existingCustomer.OrderCount.ToString();
            txtTotalSales.Text = existingCustomer.TotalSales.ToString("F2");
            txtCity.Text = existingCustomer.City;
            txtCountry.Text = existingCustomer.Country;
        }

        public string FirstName => txtFirstName.Text.Trim();
        public string LastName => txtLastName.Text.Trim();
        public int OrderCount => int.TryParse(txtOrderCount.Text, out int oc) ? oc : 0;
        public double TotalSales => double.TryParse(txtTotalSales.Text, out double ts) ? ts : 0.0;
        public string City => txtCity.Text.Trim();
        public string Country => txtCountry.Text.Trim();

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
            {
                MessageBox.Show("Name fields cannot be empty.");
                return;
            }
            if (OrderCount < 1)
            {
                MessageBox.Show("Order count must be a positive integer.");
                return;
            }
            if (TotalSales <= 0)
            {
                MessageBox.Show("Total sales must be a positive number.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
