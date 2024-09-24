using Microsoft.EntityFrameworkCore;
using OrderSystem.CoreLayer.RepositoryLayer.Contract;
using OrderSystem.RepositoryLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Rev.CoreLayer.Entites;

namespace OrderSystem.RepositoryLayer
{
    public class GenericRepositry<T> : IGenericRepositry<T> where T : BaseEntite
    {
        private readonly ApplicationDbcontext _dbcontext;

        public GenericRepositry(ApplicationDbcontext dbcontext) 
        {
            _dbcontext = dbcontext;
        }


        public void Create(T Entity)
         => _dbcontext.Set<T>().Add(Entity);
        

        public async Task<IReadOnlyList<T>> GetAllAsync()
         =>  await  _dbcontext.Set<T>().AsNoTracking().ToListAsync();
        

        public async Task<T?> GetByIdAsync(int id)
        => await _dbcontext.Set<T>().FindAsync(id);
        

        public void Update(T Entity)
         =>  _dbcontext.Set<T>().Update(Entity);
        
    }
}
