using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tp_Comerce.Models
{
    public class ProductTypes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Type Name Required")]
        [Display(Name = "Type Produit")]
        public string ProductType { get; set; }
    }
}
