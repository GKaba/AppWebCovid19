using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tp_Comerce.Models
{
    public class Order
    {

        public   Order()
        {
            OrderDetailes = new List<OrderDetaile>();
        }
        public int Id { get; set; }
        [Display(Name = "No. Commande")]
        public string OrderNo { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Nom")]
        public string  Name { get; set; }
        [Required(ErrorMessage = "Telephone is Required")]
        [Display(Name ="Telephone")]
        public long PhoneNo { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
        [Display(Name = "Date de Commande")]
        public DateTime OrderDate { get; set; }

        public List<OrderDetaile> OrderDetailes { get; set; }



    }
}
