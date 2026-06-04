namespace ApiWms.Domain.Entities.Surtido;

public class Localidad
{
    public string CODIGOLOCALIDAD { get; set; } = string.Empty;
    public int IDLOCALIDAD { get; set; }
    public int IDORDENEMBARQUE { get; set; }
    public string MOV { get; set; } = string.Empty;
    public string NUMPEDIDO { get; set; } = string.Empty;
    public int IDRECOLECCION { get; set; }
    public int SURTIDO { get; set; }
    public int IDTIPOLOCALIDAD { get; set; }
    public int TipoLocalidad { get; set; }
    public float CantRecolectada { get; set; }
    public int TipoSurtido { get; set; }
    public bool Finalizar { get; set; }
    public string Detalle { get; set; } = string.Empty;
    public int IdArea { get; set; }
}
