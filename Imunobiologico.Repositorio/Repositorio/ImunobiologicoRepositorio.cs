using Imunobiologico.EntityFramework.Data;
using Imunobiologico.Repositorio.Base;
using Imunobiologico.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imunobiologico.Repositorio.Repositorio
{
    public class ImunobiologicoRepositorio : RepositorioBase<EntityFramework.Models.Imunobiologico>, IImunobiologicoRepositorio
    {
        public ImunobiologicoRepositorio(ImunobiologicoContexto context) : base(context) { }
    }
}
