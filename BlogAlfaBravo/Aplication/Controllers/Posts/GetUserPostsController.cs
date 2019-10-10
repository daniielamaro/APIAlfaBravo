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
    public class GetUserPostsController : ControllerBase
    {

        /// <summary>
        /// Retorna publicações de um usuário.
        /// </summary>
        /// <param name="user">Nome do usuário</param>
        /// <response code="200">Publicações retornada com sucesso.</response>
        /// <response code="204">Nenhuma publicação encontrada contendo esse nome de usuário como autor.</response>
        /// <remarks>Retorno de uma lista de publicações usando um nome de usuário como filtro.</remarks>
        [HttpGet("{user}")]
        public ActionResult<List<Publicacao>> Get(string user)
        {
            List<Publicacao> pubs = new List<Publicacao>();

            pubs = Publicacoes.Pubs.FindAll(x => x.Autor.Nome.ToLower().Contains(user.ToLower()));

            return pubs;
        }

    }
}