using System;
using System.Collections.Generic;
using System.Text;
using GoodStore.Model;
using Microsoft.EntityFrameworkCore;

namespace GoodStore.Repository
{
    class BatchRepository
    {
        private ProductContext db;

        public BatchRepository(ProductContext context)
        {
            db = context;
        }

        public void Create(Batch batch)
        {
            db.Batches.Add(batch);
        }

        public void Delete(Batch batch)
        {
            db.Batches.Remove(batch);
        }

        public IEnumerable<Batch> GetAll()
        {
            return db.Batches.Include(b => b.ProductsInBatches);
        }

        public Batch Get(int id)
        {
            return db.Batches.Find(id);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
