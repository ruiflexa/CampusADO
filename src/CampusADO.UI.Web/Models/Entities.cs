using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampusADO.UI.Web.Models
{
    public class Cliente
    {
        public Cliente()
        {

        }

        [Key]
        public int ClienteId { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

    }

    public class Produto
    {
        [Key]
        public int ProdutoID { get; set; }

        public string Nome { get; set; }
        
        public decimal Preco { get; set; }

        public int Estoque { get; set; }
    }
}
