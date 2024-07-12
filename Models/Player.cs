namespace Squad.Models
{
    public class Player
    {
        public Player(string v1, string v2, string v3, string v4,string v5)
        {
            this.Code = v1;
            this.Name = v2;
            this.CountryCode = v3;
            this.Position = v4;
            this.Picture = v5;
        }

        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? CountryCode { get; set; }
        public string? Position { get; set; }
        public string? Picture { get; set; }
    }
}
