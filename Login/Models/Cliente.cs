using System.ComponentModel.DataAnnotations;

namespace p.Models
{
    public class Cliente
    {
        public int Id{get;set;}

        [Required]
        public string Nom{get;set;}
    }
}