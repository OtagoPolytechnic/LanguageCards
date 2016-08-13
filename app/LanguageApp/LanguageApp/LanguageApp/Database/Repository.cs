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
        protected readonly SQLiteAsyncConnection con;
        //protected static object locker = new object();  //  Can't lock async tasks incase of deadlocks
        // Establish connection in constructor ??
        public Repository(SQLiteAsyncConnection con)
        {
            this.con = con;
        }

        public async Task<int> CountRecords()
        {
            return await con.Table<TEntity>().CountAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            return await con.GetAsync<TEntity>(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await con.Table<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {            
            return await con.Table<TEntity>().Where(predicate).ToListAsync();
        }
        /// <summary>
        ///     Inserts or updates a entity if it already exists
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Save(TEntity entity)
        {
            if (await CheckExistince(entity))
                await con.UpdateAsync(entity);
            else
                await con.InsertAsync(entity);
        }

        // Can do singularly without list of TEntity 
        public async Task SaveList(List<TEntity> entityList)
        {
            foreach (TEntity entity in entityList)
            {
                await Save(entity);
            }
        }

        // Could be <TEntity> on delete
        public async Task Delete(TEntity entity)
        {
            if (await CheckExistince(entity))
                await con.DeleteAsync(entity);
            else
                Debug.WriteLine("Delete Failed - Entity doesn't exist");
        }

        public async Task DeleteList(List<TEntity> entityList)
        {
            foreach (TEntity entity in entityList)
            {
                await Delete(entity);
            }
        }
        /// <summary>
        ///     Checks if an entity already exists in the database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> CheckExistince(TEntity entity)
        {
            var exists = await con.Table<TEntity>()
                            .Where(x => x.id == entity.id)
                            .FirstOrDefaultAsync();
            if (exists == null)
                return false;
            else
                return true;
        }

        // Not generic however needs to happen after each insert/update/delete ??? 
        //public async Task UpdateModification()
        //{
        //    Modification lastModified = new Modification()
        //    {
        //        id = 0,
        //        lastUpdated = DateTime.Now
        //    };
        //    await Save(lastModified);
        //}




    }

}

