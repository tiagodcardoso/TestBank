using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class DadosCredito
    {
        [Range(0, 1000000.00, ErrorMessage = "O Valor do credito não pode ser maior que 1.000.000,00")]
        public double ValorCredito { get; set; }        
        public int QtdaParcelas { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }

        public TipoLiberacaoCredito TipoCredito { get; set; }
    }

    public enum TipoLiberacaoCredito
    {
        CreditoConsignado = 1,
        CreditoDireto,
        CreditoPessoaFisica,
        CreditoPessoaJuridica,
        CreditoImobiliario
    }

}
