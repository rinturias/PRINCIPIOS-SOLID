
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Technical.Evaluation.Application.DTO;

namespace Puchage.Technical.Evaluation.Application.Interfaces
{
    public interface ILoginService
    {
        Task<ResulService> LoginUsuarios(UsuarioRequestDTO usuariosRequestDTO);
        Task<ResulService> RegisterUsuarios(UsuarioRequestDTO usuariosRequestDTO);
    }
}
