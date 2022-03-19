using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Puchage.Technical.Evaluation.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Usuarios.Technical.Evaluation.Application.DTO;

namespace Usuarios.Technical.Evaluation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginService loginService;
        public LoginController(ILoginService ILoginService, ILogger<LoginController> logger)
        {
            loginService = ILoginService;
             _logger = logger;
        }

        [HttpPost("LoginAuth")]

        public async Task<IActionResult> LoginAuth([FromBody] UsuarioRequestDTO usuarioRequestDTO)
        {
            string namemethod = "C-LoginAuth";
            try
            {
                if (usuarioRequestDTO.Usuario == "") throw new Exception("debe ingresar su usuario");
                if (usuarioRequestDTO.Clave == "") throw new Exception("Debe ingresar una clave");

                var exchange = await loginService.LoginUsuarios(usuarioRequestDTO);
                _logger.LogWarning(namemethod + " ,CODERROR " + exchange.codError + " ,MENSAJE:" + exchange.error);
                return Ok(exchange);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " InnerException:" + (ex.InnerException == null ? "" : ex.InnerException.Message));
                return BadRequest(new ResulService() { success = false, codError = "501", messaje = "Error en la solicitud", error = ex.Message });
            }
        }

        [HttpPost("RegisterUsuarios")]
        public async Task<IActionResult> RegisterUsuarios([FromBody] UsuarioRequestDTO usuarioRequestDTO)
        {
            string namemethod = "C-RegisterUsuarios";
            try
            {
                if (usuarioRequestDTO.Usuario == "") throw new Exception("debe ingresar su usuario");
                if (usuarioRequestDTO.Clave == "") throw new Exception("Debe ingresar una clave");

                var resulService = await loginService.RegisterUsuarios(usuarioRequestDTO);
                _logger.LogWarning(namemethod + " ,CODERROR " + resulService.codError + " ,MENSAJE:" + resulService.error);
                return Ok(resulService);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message + " InnerException:" + (ex.InnerException == null ? "" : ex.InnerException.Message));
                return BadRequest(new ResulService() { success = false, codError = "501", messaje = "Error en la solicitud", error = ex.Message });
            }

        }
    }
}
