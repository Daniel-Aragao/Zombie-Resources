using Core.Entidades;
using Core.ValueObjects;
using Infraestrutura.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Zombie_Application.ViewModels;

namespace Zombie_Application.Controllers.API
{
    public class UsuariosController : ApiController
    {
        private IUnitOfWork uow;

        public UsuariosController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpPost]
        [Route("api/Usuario")]
        public IHttpActionResult Post([FromBody]UsuarioViewModel vm)
        {
            var usuario = uow.Usuarios.GetByLogin(vm.Login);
            if (usuario != null)
            {
                return this.BadRequest("Usuário já existente");
            }

            var novoUsuario = new Usuario()
            {
                Login = vm.Login,
                Senha = (new Senha(vm.Senha)).crypt,
                Nome = vm.Nome
            };

            var erros = novoUsuario.Validar().ToList();

            if (erros.Count > 0)
            {
                return BadRequest(JsonConvert.SerializeObject(erros));
            }

            uow.Usuarios.Add(novoUsuario);
            uow.SaveChanges();

            return Ok();
        }
    }
}
