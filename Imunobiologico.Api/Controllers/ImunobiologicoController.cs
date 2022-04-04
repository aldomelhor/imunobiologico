using Imunobiologico.Api.ViewModels;
using Imunobiologico.EntityFramework.Models;
using Imunobiologico.Negocio;
using Imunobiologico.Negocio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imunobiologico.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImunobiologicoController : ControllerBase
    {
        private readonly IImunobiologicoNegocio _imunobiologico;

        public ImunobiologicoController(IImunobiologicoNegocio imunobiologico)
        {
            _imunobiologico = imunobiologico;
        }

        [HttpGet]
        public async Task<IEnumerable<ImunobiologicoVM>> ListarImunobiologico()
        {
            var resut = _imunobiologico.Listar();

            return (IEnumerable<ImunobiologicoVM>)resut;
        }

        [HttpPost]
        public async Task<bool> AdicionarImunobiologico([FromBody] ImunobiologicoVM imunobiologico)
        {
            var result = _imunobiologico.Adicionar(imunobiologico.Fabricante, DateTime.Parse(imunobiologico.AnoLote));

            return result;

        }

        [HttpPut]
        public async Task<ActionResult<bool>> AtualizarImunobiologico([FromBody] ImunobiologicoVM imunobiologico)
        {
                        
            var result = _imunobiologico.Atualizar(imunobiologico.Id, imunobiologico.Fabricante, DateTime.Parse(imunobiologico.AnoLote));

            if (result == false)
                throw new Exception("Ano ou Fabricante inválido!");

            return result;

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> ApagarImunobiologico(int id)
        {
            var result = _imunobiologico.Apagar(id);

            return result;
        }
    }
}
