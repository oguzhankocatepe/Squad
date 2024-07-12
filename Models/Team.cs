namespace Squad.Models
{
    public class Team
    {
        public Team(string v1, string v2, string v3)
        {
            this.Code = v1;
            this.Name = v2;
            this.Picture = v3;
        }

        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Picture { get; set; }
    }
}
