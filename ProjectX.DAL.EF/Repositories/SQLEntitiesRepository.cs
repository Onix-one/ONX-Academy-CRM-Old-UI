﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectX.DAL.EF.Contexts;
using ProjectX.DAL.Interfaces;

namespace ProjectX.DAL.EF.Repositories
{
    public class SqlEntitiesRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly Context _context;
        private readonly DbSet<TEntity> _entities;
        public SqlEntitiesRepository(Context context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }
        public TEntity GetEntity(int id)
        {
            return _entities.Find(id);
        }
        public void Create(TEntity entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            _entities.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            TEntity entity = _entities.Find(id);
            if (entity != null)
                _entities.Remove(entity);
            _context.SaveChanges();
        }
    }
}
