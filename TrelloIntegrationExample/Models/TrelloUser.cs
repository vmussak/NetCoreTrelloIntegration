using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrelloIntegrationExample.Models
{
    public class TrelloUser
    {
        public string Id { get; set; }
        public string AvatarUrl { get; set; }
        public string FullName { get; set; }
        public string Initials { get; set; }

        public IEnumerable<TrelloBoard> Boards { get; set; }

        public IEnumerable<TrelloOrganization> Organizations { get; set; }

        public string GetAvatar(int size)
        {
            return $"{AvatarUrl}/{size}.png";
        }

        public IEnumerable<TrelloBoard> GetBoardsByOrganization(string idOrganization)
        {
            return Boards.Where(x => x.IdOrganization == idOrganization);
        }
    }
}
