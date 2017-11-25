using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace GoodStore.Model
{
    class ProductsInBatch
    {
        
        //public int Id { get; set; }
        //public string Name { get; set; }
        public int Quantity { get; set; }
        public int BatchId { get; set; }
        public Batch Batch { get; set; }

        [ForeignKey("Product")]
        public string ProductName { get; set; }

        public Product Product { get; set; }
    }
}
