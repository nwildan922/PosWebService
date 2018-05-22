using Pos.Model.Core;
using Pos.Repository.BaseRepository;
using Pos.Repository.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Pos.Repository.Core
{
    public class ProvinceRepository : Repository<Province>, IProvinceRepository
    {
        public ProvinceRepository(DataContext context)
            : base(context)
        {

        }
        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }
        public IEnumerable<Province> GetTop10()
        {
            return DataContext.Provinces.ToList().Take(10).ToList();
        }
    }
}