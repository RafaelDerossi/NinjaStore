namespace NinjaStore.WebApi.Core.Identidade
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
        public string LinkConfirmacaoDeCadastro { get; set; }
        public string LinkCompleteCadastro { get; set; }
        public string LinkRedefinirSenha { get; set; }
    }
}