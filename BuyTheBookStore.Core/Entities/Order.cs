using BuyTheBookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTheBookStore.BuyTheBookStore.Core.Entities
{
    public class Order:BaseEntity
    {
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Dictionary<Guid, int> OrderedBooks { get; set; }
        public double Price { get; set; }
    }
}
