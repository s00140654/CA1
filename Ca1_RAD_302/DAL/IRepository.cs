using Ca1_RAD_302.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ca1_RAD_302.DAL
{
    interface IRepository<T>:IDisposable
    {
        List<T> GetAllItems();
        T GetItemWithID(int id);
        void InsertItem(T fixture);
        void UpdateItem(T fixture);
        void DeleteItem(int id);
        void Save();
    }

    public class FixtureRepository : IRepository<Fixture>
    {
        private Ca1_RAD_302Context context;

        public FixtureRepository(Ca1_RAD_302Context context)
        {
            this.context = context;
        }

        public List<Fixture> GetAllItems()
        {
            return context.Fixtures.ToList();
        }

        public Fixture GetItemWithID(int id)
        {
            return context.Fixtures.Find(id);
        }
        public void InsertItem(Fixture fixture)
        {
            context.Fixtures.Add(fixture);
        }

        public void DeleteItem(int id)
        {
            Fixture fixture = context.Fixtures.Find(id);
            context.Fixtures.Remove(fixture);
        }

        public void UpdateItem(Fixture fixture)
        {
            context.Entry(fixture).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }





    }


}
