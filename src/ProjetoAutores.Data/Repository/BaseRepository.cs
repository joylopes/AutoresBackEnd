using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoAutores.Data.Context;
using ProjetoAutores.Domain.Entities;
using ProjetoAutores.Domain.Interfaces;

namespace ProjetoAutores.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private DbSet<T> _dataset;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }
        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public Task<T> SelectAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T>> SelectAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<T> UpdateAsync(T item)
        {
            throw new System.NotImplementedException();
        }
    }
}
