using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLeads.Comum.Commands;
using ProjetoLeads.Dominio.Commands.Usuario;
using ProjetoLeads.Dominio.Handlers.Usuarios;

namespace ProjetoLeadsApi.Controllers
{
    [Route("v1/account")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [Route("Singup")]
        [HttpPost]
        
        public GenericCommandResult SingUp(CadastrarUsuarioCommand command, [FromServices] CadastrarUsuarioHandler handle)
        {
            return (GenericCommandResult) handle.Handler(command);
        }

    }
}
