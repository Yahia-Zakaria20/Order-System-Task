using OrderSystem.CoreLayer;
using OrderSystem.CoreLayer.Entites;
using OrderSystem.CoreLayer.RepositoryLayer.Contract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;

namespace OrderSystem.RepositoryLayer.Data
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbcontext _Dbcontext;

      //  public IGenericRepositry<Product> productRepositry { get; set; }

         private   Hashtable _hashtable { get; set; }


        public UnitOfWork(ApplicationDbcontext applicationDbcontext)
        {
            _Dbcontext = applicationDbcontext;

          //  productRepositry = new GenericRepositry<Product>(applicationDbcontext);
        }

        public IGenericRepositry<T> Repositry<T>() where T : BaseEntite
        {
            var key = typeof(T).Name;

            if (!string.IsNullOrEmpty(key) &&! _hashtable.ContainsKey(key))
            {
                 _hashtable.Add(key,new GenericRepositry<T>(_Dbcontext));
            }

            return _hashtable[key] as IGenericRepositry<T>;
        }

        public async Task<int> CompleteAsync()
        {
            return await _Dbcontext.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _Dbcontext.DisposeAsync();
        }

       
    }
}
