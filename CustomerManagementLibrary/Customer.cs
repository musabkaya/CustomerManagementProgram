using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerManagementLibrary
{
    public class Customer
    {
        private string _firstName, _lastName;
        private int _orderCount;
        private double _totalSales;
        private string _city;
        private string _country;

        public static Dictionary<string, int> TierList = new Dictionary<string, int>
        {
            { "Bronze", 0 },
            { "Silver", 10 },
            { "Gold", 50 }
        };

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("First Name cannot be empty.");
                if (!value.All(char.IsLetter))
                    throw new ArgumentException("First Name must contain only letters.");
                _firstName = value.Trim();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Last Name cannot be empty.");
                if (!value.All(char.IsLetter))
                    throw new ArgumentException("Last Name must contain only letters.");
                _lastName = value.Trim();
            }
        }

        public int OrderCount
        {
            get => _orderCount;
            set
            {
                if (value < 1)
                    throw new ArgumentException("Order Count must be greater than zero.");
                _orderCount = value;
            }
        }

        public double TotalSales
        {
            get => _totalSales;
            set
            {
                if (value < 1)
                    throw new ArgumentException("Total Sales must be greater than zero.");
                _totalSales = value;
            }
        }

        public string City
        {
            get => _city;
            set => _city = string.IsNullOrWhiteSpace(value) ? "Unknown" : value.Trim();
        }

        public string Country
        {
            get => _country;
            set => _country = string.IsNullOrWhiteSpace(value) ? "Unknown" : value.Trim();
        }

        public string FullName => $"{FirstName} {LastName}";
        public double AverageOrder => _totalSales / _orderCount;

        public string CustomerTier
        {
            get
            {
                if (!TierList.Any())
                    return "No Tiers Configured";
                foreach (var tier in TierList.OrderByDescending(t => t.Value))
                {
                    if (_orderCount >= tier.Value)
                        return tier.Key;
                }
                return "Uncategorized";
            }
        }

        public Customer(string firstName, string lastName, int orderCount, double totalSales, string city = "Unknown", string country = "Unknown")
        {
            FirstName = firstName;
            LastName = lastName;
            OrderCount = orderCount;
            TotalSales = totalSales;
            City = city;
            Country = country;
        }

        public Customer()
        {
            FirstName = "Unknown";
            LastName = "Unknown";
            OrderCount = 1;
            TotalSales = 1.0;
            City = "Unknown";
            Country = "Unknown";
        }

        public override string ToString()
        {
            string tierInfo = CustomerTier == "Uncategorized" ? "N/A" : CustomerTier;
            return $"{FullName} | Orders: {OrderCount} | Total Sales: ${TotalSales:F2} | Avg: ${AverageOrder:F2} | Tier: {tierInfo} | {City}, {Country}";
        }

        public static void UpdateTier(string tierName, int threshold)
        {
            if (string.IsNullOrWhiteSpace(tierName) || threshold < 0)
                throw new ArgumentException("Tier name cannot be empty, and threshold must be non-negative.");
            TierList[tierName] = threshold;
        }

        public static IReadOnlyDictionary<string, int> GetTiers() => TierList;
    }
}
