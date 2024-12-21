using CustomerManagementLibrary;

namespace CustomerManagementUI
{
    public static class AppData
    {
        // One instance for the entire app
        public static CustomerManager Manager { get; }
            = new CustomerManager("customers.tsv", "tiers.tsv");
    }
}
