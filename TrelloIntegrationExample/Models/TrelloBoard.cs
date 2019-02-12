using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrelloIntegrationExample.Models
{
    public class TrelloBoard
    {
        public string Id { get; set; }
        public string IdOrganization { get; set; }
        public string Name { get; set; }

        public IEnumerable<TrelloCard> Cards { get; set; }

        public IEnumerable<TrelloList> Lists { get; set; }

        public IEnumerable<TrelloCard> GetCardsByList(string idList)
        {
            return Cards.Where(x => x.IdList == idList).OrderBy(x => x.Pos);
        }
    }
}
