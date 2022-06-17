using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication1.Model;


namespace WebApplication1.Controllers
{
    public class LiberacaoCreditoController : MainController
    {
        [HttpPost]
        [Route("aprovar-credito")]
        public async Task<IActionResult> AprovaCredito(DadosCredito dadosCredito)
        {
            #region Validação de entrada de dados

            if (dadosCredito == null)
            {
                return CustomResponse("Por favor preencha os campos do crédito");                
            }

            if (dadosCredito.QtdaParcelas < 5 || dadosCredito.QtdaParcelas > 72)
            {
                return CustomResponse("A quantidade minima de parcele e 5x e a maxima 72x");                
            }

            if (dadosCredito.DataPrimeiroVencimento < DateTime.Today.AddDays(15) || dadosCredito.DataPrimeiroVencimento > DateTime.Today.AddDays(40))
            {
                return CustomResponse("A data do primeiro vencimento será sempre no minimo 15 dias e no máximo 40 dias da data atual.");
            }

            if (dadosCredito.TipoCredito == TipoLiberacaoCredito.CreditoPessoaJuridica)
            {
                if (dadosCredito.ValorCredito < 15000)
                {
                    return CustomResponse("Para o crédito de pessoa jurídica, o valor mínimo a ser liberado é de R$ 15.000,00;");
                }
            }
            #endregion            

            var valorCredito = string.Empty;

            switch (dadosCredito.TipoCredito)
            {
                case TipoLiberacaoCredito.CreditoConsignado:
                    valorCredito = ValorCreditoConsignado(dadosCredito);
                    break;
                case TipoLiberacaoCredito.CreditoDireto:
                    valorCredito = ValorCreditoDireto(dadosCredito);
                    break;
                case TipoLiberacaoCredito.CreditoPessoaFisica:
                    valorCredito = ValorCreditoPessoaFisica(dadosCredito);
                    break;
                case TipoLiberacaoCredito.CreditoPessoaJuridica:
                    valorCredito = ValorCreditoPessoaJuridica(dadosCredito);
                    break;
                case TipoLiberacaoCredito.CreditoImobiliario:
                    valorCredito = ValorCreditoImobiliario(dadosCredito);
                    break;
                default:
                    break;
            }

            return CustomResponse($"O credito foi aprovado e o valor total do credito com juros é: {valorCredito}");
        }

        private string ValorCreditoConsignado(DadosCredito dadosCredito)
        {
            double taxaJuros = 1;
            double juros;
            juros = taxaJuros / 100;

            double valorTotalCredito = (dadosCredito.ValorCredito * Math.Pow((juros / 12) + 1, dadosCredito.QtdaParcelas * juros / 12)
                            / (Math.Pow(juros / 12 + 1, (dadosCredito.QtdaParcelas)) - 1));

            var valor = valorTotalCredito.ToString("n2");

            return valor;
        }

        private string ValorCreditoDireto(DadosCredito dadosCredito)
        {
            double taxaJuros = 2;
            double juros;
            juros = taxaJuros / 100;

            double valorTotalCredito = (dadosCredito.ValorCredito * Math.Pow((taxaJuros / 12) + 1, dadosCredito.QtdaParcelas * taxaJuros / 12)
                            / (Math.Pow(taxaJuros / 12 + 1, (dadosCredito.QtdaParcelas)) - 1));

            var valor = valorTotalCredito.ToString("n2");

            return valor;
        }

        private string ValorCreditoPessoaFisica(DadosCredito dadosCredito)
        {
            double taxaJuros = 3;
            double juros;
            juros = taxaJuros / 100;

            double valorTotalCredito = (dadosCredito.ValorCredito * Math.Pow((taxaJuros / 12) + 1, dadosCredito.QtdaParcelas * taxaJuros / 12)
                            / (Math.Pow(taxaJuros / 12 + 1, (dadosCredito.QtdaParcelas)) - 1));

            var valor = valorTotalCredito.ToString("n2");

            return valor;
        }

        private string ValorCreditoPessoaJuridica(DadosCredito dadosCredito)
        {
            double taxaJuros = 5;
            double juros;
            juros = taxaJuros / 100;

            double valorTotalCredito = (dadosCredito.ValorCredito * Math.Pow((taxaJuros / 12) + 1, dadosCredito.QtdaParcelas * taxaJuros / 12)
                            / (Math.Pow(taxaJuros / 12 + 1, (dadosCredito.QtdaParcelas)) - 1));

            var valor = valorTotalCredito.ToString("n2");

            return valor;
        }

        private string ValorCreditoImobiliario(DadosCredito dadosCredito)
        {
            double taxaJuros = 9;
            double juros;
            juros = taxaJuros / 100;

            double valorTotalCredito = (dadosCredito.ValorCredito * Math.Pow((taxaJuros / 12) + 1, dadosCredito.QtdaParcelas * taxaJuros / 12)
                            / (Math.Pow(taxaJuros / 12 + 1, (dadosCredito.QtdaParcelas)) - 1));

            var valor = valorTotalCredito.ToString("n2");

            return valor;
        }
    }
}
