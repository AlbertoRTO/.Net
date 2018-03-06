using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Indice.Models
{
    public class Usuarios
    {
        [Display (Name ="Id")]
        public int UsuariosId { get; set; }

        [Required(ErrorMessage = "Preencha seu nome ")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Preencha seu Telefone ")]
        public string Telefone { get; set; }

        [Required(ErrorMessage ="Preenca seu E-mail")]
        public string Email { get; set; }
    }
}