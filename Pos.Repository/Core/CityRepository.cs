using Pos.Model.Core;
using Pos.Repository.BaseRepository;
using Pos.Repository.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Pos.Repository.Core
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(DataContext context)
            : base(context)
        {

        }
        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }
        public IEnumerable<City> GetTop10()
        {
            return DataContext.Cities.ToList().Take(10).ToList();
        }
    }
}