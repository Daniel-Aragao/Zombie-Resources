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
    public class MovimentosController : ApiController
    {
        private IUnitOfWork uow;

        public MovimentosController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        //[HttpGet]
        //[Route("api/Movimentos")]
        //public IHttpActionResult Get()
        //{
        //    return Ok(uow.Movimentos.GetAll());
        //}

        [HttpGet]
        [Route("api/Movimentos/{recursoId}")]
        public IHttpActionResult Get(int recursoId)
        {
            var recurso = uow.Recursos.GetSingle(recursoId);
            if (recurso == null || !recurso.isActive)
            {
                return NotFound();
            }

            var movimentos = uow.Movimentos.GetMovements(recurso);
            if (movimentos == null)
            {
                return NotFound();
            }

            var movimentacoes = new List<MovimentoViewModel>();

            foreach(var m in movimentos)
            {
                movimentacoes.Add(new MovimentoViewModel
                {
                    Id = m.Id,
                    Antes = m.Antes,
                    Depois = m.Depois,
                    Descricao = m.Descricao,
                    TipoMovimento = m.TipoMovimento,
                    Data = m.Data,
                    RecursoId = m.RecursoId,
                    Recurso = m.Recurso,
                    ResponsavelId = m.ResponsavelId,
                    Responsavel = m.Responsavel.Nome
                });
            }

            return Ok(movimentacoes);
        }

        [HttpPost]
        [Route("api/Movimentar")]
        public IHttpActionResult Post(MovimentarViewModel vm)
        {
            var recurso = uow.Recursos.GetSingle(vm.RecursoId);
            if (recurso == null || !recurso.isActive)
            {
                return NotFound();
            }

            var usuario = uow.Usuarios.GetByLogin(vm.Usuario.Login);
            if(usuario == null || !usuario.Autenticar(vm.Usuario.Senha))
            {
                return this.BadRequest("Usuário e/ou senha incorreto(s)");
            }

            var movimento = recurso.CriarMovimento(usuario, vm.Descricao, vm.Quantidade);

            var erros = recurso.Validar().ToList();
            erros.AddRange(movimento.Validar().ToList());

            if (erros.Count > 0)
            {
                return BadRequest(JsonConvert.SerializeObject(erros));
            }

            uow.Movimentos.Add(movimento);
            uow.SaveChanges();

            return Ok();
        }
    }
}
