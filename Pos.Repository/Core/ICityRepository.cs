using Pos.Model.Core;
using Pos.Repository.BaseRepository;
using System.Collections.Generic;

namespace Pos.Repository.Core
{
    public interface ICityRepository : IRepository<City>
    {
        IEnumerable<City> GetTop10();
    }
}
