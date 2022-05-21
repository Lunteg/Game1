using Entity.SearchIn;
using Entity.SearchOut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class GameDAL
    {
        public SearchOutGame Get(SearchInGame searchIn)
        {
            SearchOutGame searchOut = new SearchOutGame();

            using (bdMyGameContext data = new bdMyGameContext())
            {
                var temp = data.Games.Where(Item => Item.Id == searchIn.UserID);
                searchOut.Total = temp.Count();

                if (searchIn.Top.HasValue)
                {
                    temp = temp.Take(searchIn.Top.Value);
                }

                if (searchIn.Skip.HasValue)
                {
                    temp = temp.Skip(searchIn.Skip.Value);
                }

                searchOut.Games = temp.ToList().Select(Item => new Entity.Game()
                {
                    Id = Item.Id,
                    Date = Item.Date,
                    Host = Item.Host,
                    Join = Item.Join
                }).ToList();
                searchOut.Count = temp.Count();
            }
            return searchOut;
        }
    }
}
