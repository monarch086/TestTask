using System.Collections.Generic;

namespace POSTerminal.DataLayer
{
    public interface IRepository<TKey, TValue>
    {
        ICollection<KeyValuePair<TKey, TValue>> GetAll();
    }
}
