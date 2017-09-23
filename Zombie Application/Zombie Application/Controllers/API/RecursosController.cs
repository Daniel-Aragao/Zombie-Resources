using Core.Entidades;
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
    //[Authorize]
    public class RecursosController : ApiController
    {
        private IUnitOfWork uow;

        public RecursosController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        [HttpGet]
        [Route("api/Recursos")]
        public IHttpActionResult Get()
        {
            return Ok(uow.Recursos.GetAll(r => r.isActive));
        }

        [HttpGet]
        [Route("api/Recursos/{recursoId}")]
        public IHttpActionResult Get(int recursoId)
        {
            var recurso = uow.Recursos.GetSingle(recursoId);
            if (recurso == null)
            {
                return NotFound();
            }
            return Ok(recurso);
        }

        [HttpPost]
        [Route("api/Recursos/Novo")]
        public IHttpActionResult Post([FromBody]NovoEditRecursoViewModel vm)
        {
            var novoRecurso = new Recurso()
            {
                Descricao = vm.Descricao,
                isActive = true,
                Quantidade = 0,
                Observacao = vm.Observacao
            };

            var erros = novoRecurso.Validar().ToList();
            if (erros.Count > 0)
            {
                return BadRequest(JsonConvert.SerializeObject(erros));
            }

            uow.Recursos.Add(novoRecurso);
            uow.SaveChanges();

            return Ok();
        }

        [HttpPost]
        [Route("api/Recursos/Edit")]
        public IHttpActionResult Edit([FromBody]NovoEditRecursoViewModel vm)
        {
            var recurso = uow.Recursos.GetSingle(vm.Id);
            if (recurso == null)
            {
                return NotFound();
            }

            recurso.Descricao = vm.Descricao;
            recurso.Observacao = vm.Observacao;

            List<KeyValuePair <string, string>> erros = recurso.Validar().ToList();
            if (erros.Count > 0)
            {
                return BadRequest(JsonConvert.SerializeObject(erros));
            }

            uow.SaveChanges();

            return Ok(recurso);
        }

        [HttpGet]
        [Route("api/Recursos/Delete/{recursoId}")]
        public IHttpActionResult Delete(int recursoId)
        {
            var recurso = uow.Recursos.GetSingle(recursoId);
            if(recurso == null)
            {
                return NotFound();
            }
            recurso.isActive = false;

            uow.SaveChanges();

            return Ok(recurso);
        }
    }
}
