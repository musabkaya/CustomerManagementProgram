using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CustomerManagementLibrary
{
    public class CustomerManager
    {
        private readonly string _customerFilePath;
        private readonly string _tierFilePath;

        public List<Customer> Customers { get; private set; } = new List<Customer>();

        public CustomerManager(string customerFilePath, string tierFilePath)
        {
            _customerFilePath = customerFilePath;
            _tierFilePath = tierFilePath;
            LoadFromFile(_customerFilePath, Customers);
            LoadTierList(_tierFilePath);
        }

        public void AddCustomer(Customer customer)
        {
            if (Customers.Any(c => c.FullName.Equals(customer.FullName, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("A customer with the same full name already exists.");

            Customers.Add(customer);
            AutoSaveCustomers();
        }

        public void EditCustomer(string existingFullName, Customer updatedCustomer)
        {
            var customer = Customers.FirstOrDefault(c => c.FullName.Equals(existingFullName, StringComparison.OrdinalIgnoreCase));
            if (customer == null) throw new Exception("Customer not found.");

            if (!customer.FullName.Equals(updatedCustomer.FullName, StringComparison.OrdinalIgnoreCase) &&
                Customers.Any(c => c.FullName.Equals(updatedCustomer.FullName, StringComparison.OrdinalIgnoreCase)))
            {
                throw new Exception("A customer with that new full name already exists.");
            }

            customer.FirstName = updatedCustomer.FirstName;
            customer.LastName = updatedCustomer.LastName;
            customer.OrderCount = updatedCustomer.OrderCount;
            customer.TotalSales = updatedCustomer.TotalSales;
            customer.City = updatedCustomer.City;
            customer.Country = updatedCustomer.Country;

            AutoSaveCustomers();
        }

        public void RemoveCustomer(string fullName)
        {
            var customer = Customers.FirstOrDefault(c => c.FullName.Equals(fullName, StringComparison.OrdinalIgnoreCase));
            if (customer == null) throw new Exception("Customer not found.");

            Customers.Remove(customer);
            AutoSaveCustomers();
        }

        // TIER MANAGEMENT
        public void AddTier(string tierName, int threshold)
        {
            Customer.UpdateTier(tierName, threshold);
            AutoSaveCustomers();
        }

        public void RemoveTier(string tierName)
        {
            if (!Customer.TierList.ContainsKey(tierName))
                throw new Exception("Tier not found.");
            Customer.TierList.Remove(tierName);
            AutoSaveCustomers();
        }

        public void EditTier(string tierName, int newThreshold)
        {
            if (!Customer.TierList.ContainsKey(tierName))
                throw new Exception("Tier not found.");
            Customer.TierList[tierName] = newThreshold;
            AutoSaveCustomers();
        }

        public void AutoSaveCustomers()
        {
            SaveToFile(_customerFilePath, Customers);
            SaveTierList(_tierFilePath);
        }

        private void SaveToFile(string filePath, List<Customer> customers)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Format: firstName, lastName, orderCount, totalSales, city, country
                foreach (var c in customers)
                {
                    writer.WriteLine($"{c.FirstName}\t{c.LastName}\t{c.OrderCount}\t{c.TotalSales}\t{c.City}\t{c.Country}");
                }
            }
        }

        private void LoadFromFile(string filePath, List<Customer> customers)
        {
            if (!File.Exists(filePath))
                return;

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split('\t');
                    if (parts.Length != 6) continue;

                    if (int.TryParse(parts[2], out int orderCount) && double.TryParse(parts[3], out double totalSales))
                    {
                        var cust = new Customer(parts[0], parts[1], orderCount, totalSales, parts[4], parts[5]);
                        customers.Add(cust);
                    }
                }
            }
        }

        private void SaveTierList(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var tier in Customer.TierList)
                {
                    writer.WriteLine($"{tier.Key}\t{tier.Value}");
                }
            }
        }

        private void LoadTierList(string filePath)
        {
            if (!File.Exists(filePath))
                return;

            Customer.TierList.Clear();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var parts = line.Split('\t');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int orderThreshold))
                    {
                        Customer.TierList[parts[0]] = orderThreshold;
                    }
                }
            }
        }
    }
}
