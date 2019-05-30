using System.ComponentModel.DataAnnotations;

namespace p.ViewModels
{
    public class Login
    {
        [Required]
        public string Usuario{get;set;}

        [Required]
        [DataType(DataType.Password)]
        public string Password{get;set;}


    }
}