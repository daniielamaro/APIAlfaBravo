using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers.Posts
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlterPublicationController : ControllerBase
    {
        /*
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Publication publicacao)
        {
            var publicacaoTemp = Publicacoes.Pubs.Find(p => p.Id == Guid.Parse(id));
            publicacaoTemp = publicacao;
            Publicacoes.Pubs[Publicacoes.Pubs.FindIndex(p => p.Id == Guid.Parse(id))] = publicacaoTemp;

            return Ok(publicacaoTemp);
        }*/
    }
}