namespace Squad.Models
{
    public class League
    {
        public League(string v1, string v2)
        {
            this.TeamCode = v1;
            this.LeagueCode = v2;
        }

        public string? TeamCode { get; set; }
        public string? LeagueCode { get; set; }
    }
}