namespace LaunchDarklyDemo.Models
{
    public class InsuranceCompanyUser
    {
        public string? LoyaltyStatus { get; set; }
        public decimal? MonthlyPremium {get; set; }
        public List<string>? BundledPackages {get; set;}

        public InsuranceCompanyUser()
        {
            LoyaltyStatus = "Gold";
            BundledPackages = new List<string>
            {
                "Home", 
                "Auto"
            };
        }
    }
}