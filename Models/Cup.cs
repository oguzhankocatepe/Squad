namespace Squad.Models
{
    public class Cup
    {
        public Cup(string v1, string v2)
        {
            this.Code = v1;
            this.Name = v2;
        }

        public string? Code { get; set; }
        public string? Name { get; set; }
    }
}