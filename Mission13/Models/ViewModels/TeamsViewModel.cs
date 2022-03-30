using System;
using System.Linq;

namespace Mission13.Models.ViewModels
{
    public class TeamsViewModel
    {
        public IQueryable<Bowler> Bowlers { get; set; }
    }
}
