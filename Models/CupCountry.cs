namespace Squad.Models
{
    public class CupCountry
    {
        public CupCountry(string v1, string v2)
        {
            this.CupCode = v1;
            this.CountryCode = v2;
        }

        public string? CupCode { get; set; }
        public string? CountryCode { get; set; }
    }
}