using System;
using System.Linq;

namespace Mission13.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlersDbContext context { get; set; }

        public EFBowlersRepository (BowlersDbContext temp)
        {
            context = temp;
        }

        public IQueryable<Bowler> Bowlers => context.Bowlers;

        public void SaveBowler(Bowler b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void UpdateBowler(Bowler b)
        {
            context.Update(b);
            context.SaveChanges();
        }

        public void DeleteBowler(Bowler b)
        {
            context.Bowlers.Remove(b);
            context.SaveChanges();
        }
    }
}


