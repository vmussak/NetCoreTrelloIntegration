using System.Collections.Generic;

namespace TrelloIntegrationExample.Models
{
    public class TrelloCard
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IdList { get; set; }
        public decimal Pos { get; set; }
        public string IdBoard { get; set; }
    }
}
