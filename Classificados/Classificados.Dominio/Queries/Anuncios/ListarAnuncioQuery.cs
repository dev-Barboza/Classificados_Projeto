using Classificados.Comum.Enum;
using Classificados.Comum.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Dominio.Queries.Anuncios
{
    public class ListarAnuncioQuery : IQuery
    {
        public bool? Ativo { get; set; }
        public void Validar()
        {

        }
 
    }
    public class ListarAnuncioQueryResult
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        
        public DateTime DataCriacao { get; set; }
        public string Categoria { get;  set; }
        public float Preco { get;  set; }
        public string Telefone { get;  set; }
        public string Endereco { get;  set; }
        public EnDisponibilidade Disponibilidade { get;  set; }
        public bool? Ativo { get; set; }
    }
}
