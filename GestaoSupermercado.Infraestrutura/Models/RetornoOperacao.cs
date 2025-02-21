namespace GestaoSupermercado.Infraestrutura.Models
{
    public class RetornoOperacao
    {
        public RetornoOperacao(bool sucesso, string mensagem)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
        }

        public bool Sucesso { get; private set; }

        public string Mensagem { get; private set; }
    }
}
