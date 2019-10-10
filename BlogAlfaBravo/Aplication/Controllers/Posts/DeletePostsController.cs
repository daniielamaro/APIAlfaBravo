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
    public class DeletePostsController : ControllerBase
    {
        /// <summary>
        /// Deleta uma publicação
        /// </summary>
        /// <param name="Id">Id da publicacao</param>
        /// <response code="200">Publicação deletada com sucesso.</response>
        /// <response code="204">Publicação não encontrada com esse ID.</response>
        /// <remarks>Publicação deletada usando o ID como filtro.</remarks>
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var publicacao = Publicacoes.Pubs.Find(x => x.Id.ToString() == id);
            Publicacoes.Pubs.Remove(publicacao);
            return Ok(publicacao);
        }
    }
}