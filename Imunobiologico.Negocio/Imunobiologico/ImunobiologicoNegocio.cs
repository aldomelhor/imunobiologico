using Imunobiologico.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Imunobiologico.EntityFramework.Models;
using Imunobiologico.Negocio.Interfaces;
using Imunobiologico.Negocio.Imunobiologico.Validacao;
using Imunobiologico.Api.ViewModels;
using System.Linq;

namespace Imunobiologico.Negocio.Imunobiologico
{
    public class ImunobiologicoNegocio : IImunobiologicoNegocio
    {
        private readonly IImunobiologicoRepositorio _imunobiologicoRepositorio;

        public ImunobiologicoNegocio(IImunobiologicoRepositorio imunobiologicoRepositorio)
        {
            _imunobiologicoRepositorio = imunobiologicoRepositorio;
        }
                
        public bool Adicionar(string fabricante, DateTime anoLote)
        {
            var retorno = false;
            var EF = new EntityFramework.Models.Imunobiologico();

            if (new ValidarImunobiologico().isValid(fabricante, anoLote))
            {
                EF.Fabricante = fabricante;
                EF.AnoLote = anoLote.Year;

                _imunobiologicoRepositorio.Adicionar(EF);
                retorno = true;
            }
            return retorno;
        }

        public bool Atualizar(int id, string fabricante, DateTime anoLote)
        {
            var retorno = false;

            if (new ValidarImunobiologico().isValid(fabricante, anoLote))
            {
                var EF = _imunobiologicoRepositorio.Obter(id);

                EF.Fabricante = fabricante;
                EF.AnoLote = anoLote.Year;

                _imunobiologicoRepositorio.Atualizar(EF);
                retorno = true;
            }
            
            return retorno;
        }

        public bool Apagar(int id)
        {
            var retorno = false;
            var EF = _imunobiologicoRepositorio.Obter(id);

            if (EF != null)
            {
                _imunobiologicoRepositorio.Apagar(EF);
                retorno = true;
            }

            return retorno;

        }

        public List<ImunobiologicoVM> Listar()
        {
            var EF = _imunobiologicoRepositorio.Listar();
            return EF.Select(x => new ImunobiologicoVM { Id = x.Id, Fabricante = x.Fabricante, AnoLote = x.AnoLote.ToString() }).ToList();

        }

    }
}
