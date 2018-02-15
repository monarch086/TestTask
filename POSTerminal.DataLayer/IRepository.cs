using System.Collections.Generic;

namespace POSTerminal.DataLayer
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
    }
}
