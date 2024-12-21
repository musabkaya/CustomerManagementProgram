using System;
using System.Linq;
using System.Windows.Forms;
using CustomerManagementLibrary;

namespace CustomerManagementUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshCustomerGrid();
        }

        private void RefreshCustomerGrid()
        {
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = AppData.Manager.Customers.Select(c => new
            {
                c.FirstName,
                c.LastName,
                c.OrderCount,
                c.TotalSales,
                c.City,
                c.Country,
                Tier = c.CustomerTier
            }).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditCustomerForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var newCustomer = new Customer(
                            form.FirstName,
                            form.LastName,
                            form.OrderCount,
                            form.TotalSales,
                            form.City,
                            form.Country
                        );
                        AppData.Manager.AddCustomer(newCustomer);
                        RefreshCustomerGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding customer: " + ex.Message);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null)
            {
                MessageBox.Show("Please select a customer first.");
                return;
            }

            string fullName = dgvCustomers.CurrentRow.Cells["FirstName"].Value + " " +
                              dgvCustomers.CurrentRow.Cells["LastName"].Value;

            var existingCustomer = AppData.Manager.Customers.FirstOrDefault(c => c.FullName == fullName);
            if (existingCustomer == null)
            {
                MessageBox.Show("Customer not found.");
                return;
            }

            using (var form = new AddEditCustomerForm(existingCustomer))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var updatedCustomer = new Customer(
                            form.FirstName,
                            form.LastName,
                            form.OrderCount,
                            form.TotalSales,
                            form.City,
                            form.Country
                        );
                        AppData.Manager.EditCustomer(existingCustomer.FullName, updatedCustomer);
                        RefreshCustomerGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error editing customer: " + ex.Message);
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null)
            {
                MessageBox.Show("Please select a customer first.");
                return;
            }

            string fullName = dgvCustomers.CurrentRow.Cells["FirstName"].Value + " " +
                              dgvCustomers.CurrentRow.Cells["LastName"].Value;

            if (MessageBox.Show($"Remove customer {fullName}?",
                                "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    AppData.Manager.RemoveCustomer(fullName);
                    RefreshCustomerGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error removing customer: " + ex.Message);
                }
            }
        }

        private void btnHomePage_Click(object sender, EventArgs e)
        {
            // Return to HomePage
            var home = new HomePageForm();
            home.FormClosed += (s, args) => this.Show();
            home.Show();
            this.Hide();
        }
    }
}
