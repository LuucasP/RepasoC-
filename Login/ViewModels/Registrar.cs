using System.ComponentModel.DataAnnotations;

namespace p.ViewModels{

    public class Registrar{

        public string Usuario{get;set;}

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email{get;set;}

        [Required]
        [DataType(DataType.Password)]
        public string Password{get;set;}
        


        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "La contraseña no coincide")]
        public string PasswordConfirmacion{get;set;}
        
    
        
    
    }

}