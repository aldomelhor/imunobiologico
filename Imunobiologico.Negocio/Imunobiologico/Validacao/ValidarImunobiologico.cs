using System;
using System.Collections.Generic;
using System.Text;

namespace Imunobiologico.Negocio.Imunobiologico.Validacao
{
    public class ValidarImunobiologico
    {
        private readonly List<string> FabricantesValidos = new List<string> { "PFIZER", "SINOVAC" };
        public bool isValid(string fabricante, DateTime data)
        {
            var retorno = false;
            //Fabricante (Poderá aceitar apenas PFIZER ou SINOVAC)
            //Ano do lote (deverá ser igual ou maior que o ano anterior).

            if (FabricantesValidos.Contains(fabricante.ToUpper()) && data.Year >= DateTime.Now.AddYears(-1).Year)
                return true;

            return retorno;

        }
    }
}
