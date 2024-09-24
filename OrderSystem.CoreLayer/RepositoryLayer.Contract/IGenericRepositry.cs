using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;

namespace OrderSystem.CoreLayer.RepositoryLayer.Contract
{
    public interface IGenericRepositry<T> where T :BaseEntite
    {
        public Task<IReadOnlyList<T>> GetAllAsync();

        public void Create(T Entity);

        public void Update(T Entity);

        public Task<T?> GetByIdAsync(int id);  



    }
}
