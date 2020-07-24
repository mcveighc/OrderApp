using System.Collections.Generic;

namespace BGLOrderApp.Data.Repositories
{
    public interface IRepository<TKey, TModel>
    {
        void Create(TModel model);
        TModel Get(TKey key);
        IEnumerable<TModel> GetAll();
        void Update(TModel model);
        void Delete(TKey key);
    }
}
