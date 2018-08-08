using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace SportsWebApp.Models
{
    public interface IPlayersService 
    {
        
            Task DeleteAsync(long id);
            Player Find(long id);
            Task<Player> FindAsync(long id);
            IQueryable<Player> GetAll(int? count = null, int? page = null);
            Task<Player[]> GetAllAsync(int? count = null, int? page = null);
            Task SaveAsync(Player player);
        
    }
}
