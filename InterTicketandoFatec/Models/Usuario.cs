using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterTicketandoFatec.Models
{
    public class Usuario : Pessoa
    {
        [Required]
        [MaxLength(15)]
        public string RG { get; set; }

        [MaxLength(20)]
        public string RA { get; set; }

        [MaxLength(200)]
        public string Curso { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Login { get; set; }

        [Required]
        [MaxLength(20)]
        public string Senha { get; set; }
    }
}