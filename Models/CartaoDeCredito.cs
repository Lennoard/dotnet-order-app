namespace dotnet_order_app.Models;

public class CartaoDeCredito : Pagamento
{
    public string Numero { get; set; }

    private Dictionary<string, bool> Autorizacoes { get; set; } = new Dictionary<string, bool>();

    override public void confirma()
    {
        throw new NotImplementedException();
    }

    public void autorizaDebito()
    {
        var Id = PedidoId.ToString();
        Autorizacoes[Id] = true;
    }
}
