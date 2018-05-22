using Pos.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProvinceRepository Provinces { get; }
        int Complete();
    }
}
