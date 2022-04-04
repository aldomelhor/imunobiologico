using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Imunobiologico.EntityFramework.Models
{
    public class Imunobiologico: EntityFramework.Base.EntidadeBase
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "O campo fabricante é obrigatório")]
        [StringLength(30, ErrorMessage = "Tamanho máximo 50 caracteres")]
        public string Fabricante { get; set; }
        
        [Required(ErrorMessage = "O campo ano do lote é obrigatório")]
        public int AnoLote { get; set; }

    }
}
