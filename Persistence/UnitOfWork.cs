using Domain.Contracts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class UnitOfWork(OrderSystemDbcontext _dbcontext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repositories = [];

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
           //get type name 
           var TypeName = typeof(TEntity).Name; 
           //Dictionary
           if(_repositories.TryGetValue(TypeName,out object value))
                return(IGenericRepository<TEntity>)value;
            else
            {
                //create obj
                var Repo =new GenericRepository<TEntity>(_dbcontext);
                //save obj in Dic 
                _repositories[TypeName] = Repo;
                //Return Obj
                return Repo;
            }


        }



        public async Task<int> SaveChangesAsync()
        {
          return  await _dbcontext.SaveChangesAsync();
        }
    }
}
