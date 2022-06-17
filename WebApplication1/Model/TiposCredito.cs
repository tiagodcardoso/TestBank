using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class TiposCredito
    {
        [Range(15000.00, 1000000.00, ErrorMessage = "O Valor mínimo de credito e de 15.000,00")]
        public string CreditoPessoaJuridica { get; set; }
        public string CreditoConsignado { get; set; }
        public string CreditoDireto { get; set; }
        public string CreditoPessoaFisica { get; set; }
        public string CreditoImobiliario { get; set; }
    }
}
