namespace StarWars.Core.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IDroidRepository
    {
        Task<Droid> Get(int id);
        Task<IEnumerable<Droid>> GetByName(string name);
    }
}