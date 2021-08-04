using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace WebApplication1.Models
{
    public class ContactUS
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5,ErrorMessage ="mini length is 5 charcter")]
        [StringLength(15,ErrorMessage ="max length is 15 charcter")]
        public string Name { get; set; }
        [Required]

        public string Message { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
    }
}
