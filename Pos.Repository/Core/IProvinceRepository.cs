using Pos.Model.Core;
using Pos.Repository.BaseRepository;
using System.Collections.Generic;

namespace Pos.Repository.Core
{
    public interface IProvinceRepository : IRepository<Province>
    {
        IEnumerable<Province> GetTop10();
    }
}
