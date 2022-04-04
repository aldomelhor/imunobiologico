using Imunobiologico.Api.ViewModels;
using Imunobiologico.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imunobiologico.Negocio.Interfaces
{
    public interface IImunobiologicoNegocio
    {
        bool Adicionar(string fabricante, DateTime anoLote);
        bool Atualizar(int id, string fabricante, DateTime anoLote);
        bool Apagar(int id);

        List<ImunobiologicoVM> Listar();
        //IEnumerable<IImunobiologicoNegocio> Listar();
        //bool ListarPorId(int id);
    }
}
