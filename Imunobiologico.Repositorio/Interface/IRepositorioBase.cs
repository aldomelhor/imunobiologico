using Imunobiologico.EntityFramework.Base;
using Imunobiologico.Repositorio.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imunobiologico.Repositorio.Interface
{
    public interface IRepositorioBase<TEntidade> where TEntidade : EntidadeBase
    {
        TEntidade Adicionar(TEntidade entidade);
        TEntidade Atualizar(TEntidade entidade);
        TEntidade Apagar(TEntidade entidade);

        TEntidade Obter(int id);
        List<TEntidade> Listar();
    }
}
