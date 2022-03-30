using System;
using System.Linq;

namespace Mission13.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }

        void SaveBowler(Bowler b);
        void UpdateBowler(Bowler b);
        void DeleteBowler(Bowler b);
    }
}
