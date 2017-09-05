namespace StarWars.Data.InMemory
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Core.Data;
    using Core.Models;

    public class DroidRepository : IDroidRepository
    {
        private readonly List<Droid> _droids = new List<Droid>
        {
            new Droid {Id = 1, Name = "First R2-D2"},
            new Droid {Id = 2, Name = "Second R2-D2-2"},
            new Droid {Id = 3, Name = "Third R2-D2-3"},
            new Droid {Id = 4, Name = "Fourht R2-D2-4"},
        };

        public Task<Droid> Get(int id)
        {
            return Task.FromResult(_droids.FirstOrDefault(x => x.Id == id));
        }

        public Task<IEnumerable<Droid>> GetByName(string name)
        {
            return Task.FromResult(_droids.Where(x => x.Name.Contains(name)));
        }
    }
}
