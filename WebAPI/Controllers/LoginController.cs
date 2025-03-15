using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Custom;
using WebAPI.Models;
using WebAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DBContext _dbContext;
        private readonly Utilities _utilities;
        public LoginController(DBContext dbContext, Utilities utilities)
        {
            _dbContext = dbContext;
            _utilities = utilities;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO objeto)
        {
            var usuarioEncontrado = await _dbContext.Usuarios
                                                    .Where(u =>
                                                    u.Correo == objeto.Correo &&
                                                        u.Clave == _utilities.encryptSHA256(objeto.Clave)
                                                      ).FirstOrDefaultAsync();

            if (usuarioEncontrado == null)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilities.createJWT(usuarioEncontrado) });
        }
    }
}
