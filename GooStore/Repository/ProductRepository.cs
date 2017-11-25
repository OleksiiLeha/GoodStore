using System;
using System.Collections.Generic;
using System.Text;
using GoodStore.Model;

namespace GoodStore.Repository
{
    class ProductRepository
    {
        private ProductContext db;

        public ProductRepository(ProductContext context)
        {
            db = context;
        }

        public void Create(Product product)
        {
            db.Products.Add(product);
        }

        public void Delete(Product product)
        {
            db.Products.Remove(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products;
        }

        public Product Get(string name)
        {
            return db.Products.Find(name);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
