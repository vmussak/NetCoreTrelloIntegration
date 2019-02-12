using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrelloIntegrationExample.Models
{
    public class TrelloList
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Pos { get; set; }
    }
}
