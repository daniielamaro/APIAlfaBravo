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
    public class GetPostsByTitleController : ControllerBase
    {

        /// <summary>
        /// Retorna publicações por titulo.
        /// </summary>
        /// <param name="titulo">Titulo da publicacao</param>
        /// <response code="200">Publicações retornada com sucesso.</response>
        /// <response code="204">Nenhuma publicação encontrada contendo esse titulo.</response>
        /// <remarks>Retorno de uma lista de publicações usando um titulo como filtro.</remarks>
        [HttpGet("{titulo}")]
        public ActionResult<List<Publicacao>> Get(string titulo)
        {
            List<Publicacao> pubs = new List<Publicacao>();

            pubs = Publicacoes.Pubs.FindAll(x => x.Titulo.ToLower().Contains(titulo.ToLower()));

            return Ok(pubs);
        }

    }
}