using Inventory.Helpers;
using Inventory.Infrastructure.Entities;
using Inventory.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Inventory.Infrastructure
{
    public class PersistenceRepository : IPersistenceRepository, IDisposable
    {
        protected DbContext Context;
        private ILogger Logger;

        public string ConnectionString
        {
            get; private set;
        }
        public PersistenceRepository(InventoryContext inventoryContext)
        {
            this.Context = inventoryContext;
            //this.ConnectionString = inventoryContext.Database.Connection.ConnectionString;
            this.Logger = new Logger();
        }

        //public PersistenceRepository(string connectionString)
        //{
        //     this.Context = new InventoryContext(connectionString);
        //    this.ConnectionString = connectionString;
        //    this.Logger = new Logger();
        //    // this.Context.Database.CreateIfNotExists();
        //}

        public IQueryable<T> GetAll<T>() where T : class
        {
            return this.Context.Set<T>().AsQueryable();
        }

        public IQueryable<T> GetAll<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return this.Context.Set<T>().Where(predicate);
        }

        public void Add<T>(T entity) where T : class
        {
            this.Context.Set<T>().Add(entity);
        }

        public void Remove<T>(T entity) where T : class
        {
            this.Context.Set<T>().Remove(entity);
        }


        public int SaveChanges()
        {
            try
            {
                return this.Context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.Logger.Log($"Message:{ex.Message}| Stacktrace:{ex.StackTrace}");//todo
                throw;
            }
        }

        private bool disposed = false;
        public void Dispose()
        {
            if (!this.disposed)
            {
                if (this.Context != null)
                {
                    this.Context.Dispose();
                }
            }
            this.disposed = true;
            GC.SuppressFinalize(this);
        }
        public IDbConnection GetNewDbConnection()
        { 
            return new SqlConnection(this.ConnectionString); 
        }
        //public IDbConnection GetNewDbConnection()
        //{
        //    if (!string.IsNullOrEmpty(this.ConnectionString))
        //    {
        //        return new SqlConnection(this.ConnectionString);
        //    }
        //    throw new ApplicationException("temp implementation: todo- implement properly");
        //}
    }
}
