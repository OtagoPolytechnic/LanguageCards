using LanguageApp.Database.Interfaces;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using LanguageApp.Database.Models;
using System.Diagnostics;

namespace LanguageApp.Database
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IModel
    {
        protected readonly SQLiteAsyncConnection connection;
        protected static object locker = new object();
        // Establish connection in constructor ??
        public Repository(SQLiteAsyncConnection connection)
        {
            this.connection = connection;
        }

        public async Task<int> CountRecords()
        {
            return await connection.Table<TEntity>().CountAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            return await connection.GetAsync<TEntity>(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await connection.Table<TEntity>().ToListAsync();
        }

        // Can do singularly without list of TEntity 
        public async Task Save(List<TEntity> entityList)
        {
            foreach (TEntity entity in entityList)
            {                
                if (await CheckExistince(entity))
                    await connection.UpdateAsync(entity);   
                else
                    await connection.InsertAsync(entity);
            }
        }

        // Could be <TEntity> on delete
        public async Task Delete(List<TEntity> entityList)
        {
            foreach (TEntity entity in entityList)
            {
                if (await CheckExistince(entity))
                    await connection.DeleteAsync(entity);
                else
                    Debug.WriteLine("Delete Failed - Entity doesn't exist");

            }
        }
        /// <summary>
        ///     Checks if an entity already exists in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> CheckExistince(TEntity entity)
        {
            var exists = await connection.Table<TEntity>()
                            .Where(x => x.id == entity.id)
                            .FirstOrDefaultAsync();
            if (exists == null)
                return false;
            else
                return true;
        }




    }

}

