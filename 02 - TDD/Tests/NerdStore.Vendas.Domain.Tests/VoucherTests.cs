using System;
using System.Linq;
using Xunit;

namespace NerdStore.Vendas.Domain.Tests
{
    public class VoucherTests
    {
        [Fact(DisplayName = "Validar Voucher Tipo Valor Valido")]
        [Trait("Categoria", "Vendas - Voucher")]
        public void Voucher_ValidarTipoValorVoucher_DeveEstarValido()
        {
            // Arrange
            var voucher = new Voucher("PROMO-15-REAIS", null, 15, TipoDescontoVoucher.Valor, 1, DateTime.Now.AddDays(15), true, false);

            // Act
            var result = voucher.ValidarSeAplicavel();

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Validar Voucher Tipo Porcentagem Valido")]
        [Trait("Categoria", "Vendas - Voucher")]
        public void Voucher_ValidarTipoPorcentagemVoucher_DeveEstarValido()
        {
            // Arrange
            var voucher = new Voucher("PROMO-15-PORCENTO", 15, 0, TipoDescontoVoucher.Porcentagem, 1, DateTime.Now.AddDays(15), true, false);

            // Act
            var result = voucher.ValidarSeAplicavel();

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Validar Voucher Tipo Valor Invalido")]
        [Trait("Categoria", "Vendas - Voucher")]
        public void Voucher_ValidarTipoValorVoucher_DeveEstarInvalido()
        {
            // Arrange
            var voucher = new Voucher("", null, null, TipoDescontoVoucher.Valor, 0, DateTime.Now.AddDays(-1), false, true);

            // Act
            var result = voucher.ValidarSeAplicavel();

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(6, result.Errors.Count);
            Assert.Contains(VoucherAplicavelValidation.AtivoErroMsg, result.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(VoucherAplicavelValidation.CodigoErroMsg, result.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(VoucherAplicavelValidation.DataValidadeErrorMsg, result.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(VoucherAplicavelValidation.QuantidadeErroMsg, result.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(VoucherAplicavelValidation.UtilizadoErroMsg, result.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(VoucherAplicavelValidation.ValorDescontoErroMsg, result.Errors.Select(c => c.ErrorMessage));
        }

        [Fact(DisplayName = "Validar Voucher Tipo Porcentagem Invalido")]
        [Trait("Categoria", "Vendas - Voucher")]
        public void Voucher_ValidarTipoPorcentagemVoucher_DeveEstarInvalido()
        {
            // Arrange
            var voucher = new Voucher("", null, null, TipoDescontoVoucher.Porcentagem, 0, DateTime.Now.AddDays(-1), false, true);

            // Act
            var result = voucher.ValidarSeAplicavel();

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(6, result.Errors.Count);
            Assert.Contains(VoucherAplicavelValidation.AtivoErroMsg, result.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(VoucherAplicavelValidation.CodigoErroMsg, result.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(VoucherAplicavelValidation.DataValidadeErrorMsg, result.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(VoucherAplicavelValidation.QuantidadeErroMsg, result.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(VoucherAplicavelValidation.UtilizadoErroMsg, result.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(VoucherAplicavelValidation.PercentualDescontoErroMsg, result.Errors.Select(c => c.ErrorMessage));
        }
    }
}