using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GoodStore.Model
{
    class Product
    {
        [Key]
        public string Name { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public List<ProductsInBatch> Products { get; set; }
    }
}
