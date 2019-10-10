using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAlfaBravo.Aplication;
using BlogAlfaBravo.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAlfaBravo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlterPostsController : ControllerBase
    {
        /// <summary>
        /// Altera uma publicação
        /// </summary>
        /// <response code="200">Publicação alterada com sucesso.</response>
        /// <response code="404">Publicação não encontrada com este ID.</response>
        /// <remarks>Alteração realizada usando o Id da publicação</remarks>
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Publicacao publicacao)
        {
            var publicacaoTemp = Publicacoes.Pubs.Find(p => p.Id == Guid.Parse(id));
            publicacaoTemp = publicacao;
            Publicacoes.Pubs[Publicacoes.Pubs.FindIndex(p => p.Id == Guid.Parse(id))] = publicacaoTemp;

            return Ok(publicacaoTemp);
        }
    }
}