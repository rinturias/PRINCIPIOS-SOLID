using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using Polly.CircuitBreaker;

using Puchage.Technical.Evaluation.Application.Interfaces;

using Puchage.Technical.Evaluation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Technical.Evaluation.Application.DTO;
using Usuarios.Technical.Evaluation.Application.encryption;
using Usuarios.Technical.Evaluation.Domain.Entitites.Usuarios;
using Usuarios.Technical.Evaluation.Domain.Interfaces.Repositories;

namespace Puchage.Technical.Evaluation.Application.Services
{
    public class UsuarioService: ILoginService
    {
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly IEncryption _encryption;
        private readonly ILogger<UsuarioService> _logger;
        public UsuarioService(IUsuariosRepository IUsuariosRepository, IEncryption encryption, ILogger<UsuarioService> logger)
        {
            _usuariosRepository = IUsuariosRepository;
            _encryption = encryption;
            _logger = logger;
        }

 

        public async Task<ResulService> LoginUsuarios(UsuarioRequestDTO usuariosRequestDTO)
        {
            string namemethod = "S-LoginUsuarios";
            var clave = _encryption.encryption(usuariosRequestDTO.Clave);
            User objUsuario = new()
            {
                usuario = usuariosRequestDTO.Usuario,
                clave= clave
            };

           var validateUser= await _usuariosRepository.LoginUsuarios(objUsuario);
            _logger.LogWarning(namemethod + " ,result validateUser: " + validateUser.ToString() );

            if (validateUser == true) {
               return new ResulService { codError = "0", success = true, messaje = "Usuario validado exitosamente" }; 
            }else
            {
               return new ResulService { codError = "501", success = true, messaje = "Usuario no existe" };
            }

        }

        public async Task<ResulService> RegisterUsuarios(UsuarioRequestDTO usuariosRequestDTO)
        {
            string namemethod = "S-RegisterUsuarios";
            var newClave = _encryption.encryption(usuariosRequestDTO.Clave);
            User objUsuario = new()
            {
                usuario = usuariosRequestDTO.Usuario,
                clave = newClave
            };
           await  _usuariosRepository.RegisterUsuarios(objUsuario);
            _logger.LogWarning(namemethod + " ,Registro Correctamente el usuario: "+ usuariosRequestDTO.Usuario);
            return new ResulService { codError = "0", success = true, messaje = "Usuario registrado exitosamente" };
        }
    }
}
