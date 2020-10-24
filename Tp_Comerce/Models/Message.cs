using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tp_Comerce.Models
{
    public class Message
    {
        [Key]
        [Required]
        public string Id { get; set; }
        [Required]
        public string  Nom { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Sujet { get; set; }

        [Required]
        [Display(Name ="Message")]
        public string  Msg { get; set; }

    }
}
