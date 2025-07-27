﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<TEntity?> GetByIdAsync(int id);
        public Task AddAsync(TEntity entity);
        public void Remove(TEntity entity);
        public void Update(TEntity entity);

    }
}
