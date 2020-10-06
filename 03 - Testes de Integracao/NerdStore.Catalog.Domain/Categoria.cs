using NerdStore.Core.DomainObjects;
using System.Collections.Generic;

namespace NerdStore.Catalog.Domain
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }
        public string Codigo { get; private set; }
        public ICollection<Produto> Produtos { get; set; }

        public Categoria() { }

        public Categoria(string nome, string codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }
    }
}