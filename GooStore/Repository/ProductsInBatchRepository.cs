using System;
using System.Collections.Generic;
using System.Text;
using GoodStore.Model;

namespace GoodStore.Repository
{
    class ProductsInBatchRepository
    {
        private ProductContext db;

        public ProductsInBatchRepository(ProductContext context)
        {
            db = context;
        }

        public void Create(ProductsInBatch productsInBatch)
        {
            db.ProductsInBatches.Add(productsInBatch);
        }

        public void Delete(ProductsInBatch productsInBatch)
        {
            db.ProductsInBatches.Remove(productsInBatch);
        }

        public IEnumerable<ProductsInBatch> GetAll()
        {
            return db.ProductsInBatches;
        }

        public ProductsInBatch Get(int id)
        {
            return db.ProductsInBatches.Find(id);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
