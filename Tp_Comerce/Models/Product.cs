using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tp_Comerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Name Required")]
        [Display(Name = "Nom Produit")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price Required")]
        [Display(Name = "Prix")]
        //[Column(TypeName = "decimal(7, 2)")]
        public float Price { get; set; }
        [Display(Name = "Image")]
        public string Image { get; set; }
        [Display(Name = "Discription")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Availability is Required")]
        [Display(Name = "Disponibile")]
        public bool IsAvailable { get; set; }
        [Display(Name = "Type Produit")]
        [Required(ErrorMessage = "Product Type is Required")]
        public int ProductTypeId { get; set; }
        [ForeignKey("ProductTypeId")]
        public ProductTypes ProductTypes { get; set; }


    }
}
