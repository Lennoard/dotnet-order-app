namespace dotnet_order_app.Models;

public class Boleto : Pagamento
{
    public string Codigo { get; set; }

    private Dictionary<string, bool> Autorizacoes { get; set; } = new Dictionary<string, bool>();

    override public void confirma()
    {
        var Id = PedidoId.ToString();
        Autorizacoes[Id] = true;
    }
}
