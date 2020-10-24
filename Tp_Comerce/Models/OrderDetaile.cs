using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tp_Comerce.Models
{
    public class OrderDetaile
    {
        public int Id { get; set; }
        [Display(Name ="Order")]
        public int OrderId{ get; set; }
        [Display(Name = "Produit")]
        public int ProductId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
