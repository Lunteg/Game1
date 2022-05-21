using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class GameBL
    {
        public void GetGames(Entity.SearchIn.SearchInGame game)
        {
            new DAL.GameDAL().Get(game);
        }
    }
}
