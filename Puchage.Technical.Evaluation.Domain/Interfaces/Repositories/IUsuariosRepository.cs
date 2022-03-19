using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.Technical.Evaluation.Domain.Interfaces.Repositories
{
   public interface IUsuariosRepository
    {
        Task<bool> LoginUsuarios(Entitites.Usuarios.User usuarios);
        Task<bool> RegisterUsuarios(Entitites.Usuarios.User usuarios);
    }
}
