using System;

namespace NerdStore.Vendas.Domain
{
    public class Voucher
    {
        public string Codigo { get; private set; }
        public decimal? PercentualDesconto { get; private set; }
        public decimal? ValorDesconto { get; private set; }
        public TipoDescontoVoucher TipoDescontoVoucher { get; private set; }
        public int Quantidade { get; private set; }
        public DateTime DataValidade { get; private set; }
        public bool Ativo { get; private set; }
        public bool Utilizado { get; private set; }

        public bool ValidarSeAplicavel()
        {
            return true;
        }
    }

    public enum TipoDescontoVoucher
    {
        Porcentagem = 0,
        Valor = 1
    }
}