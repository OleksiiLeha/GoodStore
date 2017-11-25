using System;
using System.Collections.Generic;
using System.Text;

namespace GoodStore.Model
{
    class Batch
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Action { get; set; }
        public List<ProductsInBatch> ProductsInBatches { get; set; }
    }
}
