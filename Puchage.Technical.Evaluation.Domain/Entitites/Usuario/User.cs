using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.Technical.Evaluation.Domain.Entitites.Usuarios
{
    [Table("usuarios")]
    public class User
    {

        [Key]
        public int codUsuario { get; set; }  
        public string usuario { get; set; }
        public string clave { get; set; }

    }
}
