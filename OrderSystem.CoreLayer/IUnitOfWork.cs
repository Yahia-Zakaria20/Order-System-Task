using OrderSystem.CoreLayer.Entites;
using OrderSystem.CoreLayer.RepositoryLayer.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;

namespace OrderSystem.CoreLayer
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        public IGenericRepositry<T> Repositry<T>()where T : BaseEntite;


        public Task<int> CompleteAsync();
    }
}
