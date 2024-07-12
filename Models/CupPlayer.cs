using System.Transactions;

namespace Squad.Models
{
    public class CupPlayer : Player
    {
        public string? CupCode { get; set; }
        public CupPlayer(string v0, string v1, string v2, string v3, string v4,string v5) : base(v1, v2, v3, v4,v5)
        {
            this.CupCode = v0;
        }            
    }
}
