//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;


//namespace SportsWebApp.Models
//{
//    public class PlayersService : IPlayersService
//    {
//        private readonly PlayersDbContext _context;

//        public PlayersService()
//        {
//            var options = new DbContextOptionsBuilder<PlayersDbContext>()
//                .UseInMemoryDatabase("SportsWebApp")
//                .Options;

//            _context = new PlayersDbContext(options);
//        }

//        public PlayersService(PlayersDbContext context)
//        {
//            _context = context;
//        }

//        public async Task DeleteAsync(long id)
//        {
//            _context.Players.Remove(new Player { Id = id });
//            await _context.SaveChangesAsync();
//        }

//        public Player Find(long id)
//        {
//            return _context.Players.FirstOrDefault(x => x.Id == id);
//        }

//        public Task<Player> FindAsync(long id)
//        {
//            return _context.Players.FirstOrDefaultAsync(x => x.Id == id);
//        }

//        public IQueryable<Player> GetAll(int? count = null, int? page = null)
//        {
//            var actualCount = count.GetValueOrDefault(10);

//            return _context.Players
//                    .Skip(actualCount * page.GetValueOrDefault(0))
//                    .Take(actualCount);
//        }

//        public Task<Player[]> GetAllAsync(int? count = null, int? page = null)
//        {
//            return GetAll(count, page).ToArrayAsync();
//        }

//        public async Task SaveAsync(Player player)
//        {
//            var isNew = player.Id == default(long);

//            _context.Entry(player).State = isNew ? EntityState.Added : EntityState.Modified;

//            await _context.SaveChangesAsync();
//        }
//    }
//}
