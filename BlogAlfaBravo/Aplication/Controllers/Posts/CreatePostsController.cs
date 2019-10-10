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
    public class CreatePostsController : ControllerBase
    {

        /// <summary>
        /// Cria uma nova publicação
        /// </summary>
        /// <param name="publicacao">Objeto publicacao</param>
        /// <response code="200">Publicação criada com sucesso.</response>
        /// <response code="400">Publicação com parametros inválidos!</response>
        /// <remarks>Publicação criada recebendo um novo objeto publicacao com parametros válidos.</remarks>
        [HttpPost]
        public ActionResult Post(Publicacao publicacao)
        {
            Publicacoes.Pubs.Add(publicacao);
            return Ok(publicacao);
        }

    }
}