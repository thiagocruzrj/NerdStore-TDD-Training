﻿using System;

namespace NerdStore.Vendas.Domain
{
    public class Voucher
    {
        public string Codigo { get; set; }
        public decimal? PercentualDesconto { get; set; }
        public decimal? ValorDesconto { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataValidade { get; set; }
        public bool Ativo { get; set; }
        public bool Utilizado { get; set; }
    }
}