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
    public class GetPostsController : ControllerBase
    {

        /// <summary>
        /// Retorna todas publicações.
        /// </summary>
        /// <response code="200">Publicações retornada com sucesso.</response>
        /// <response code="204">Nenhuma publicação encontrada contendo esse titulo.</response>
        /// <remarks>Retorno de uma lista de publicações usando um titulo como filtro.</remarks>
        [HttpGet]
        public ActionResult<List<Publicacao>> Get()
        {
            return Ok(Publicacoes.Pubs);
        }        

    }
}