﻿using ErpApi.Data;
using ErpApi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpApi.Repository
{
    public class BaseRepository : IBaseRepository
    {

        private readonly DataContext _context;
         public BaseRepository(DataContext context)
    {
        _context = context;
    }


    
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}
