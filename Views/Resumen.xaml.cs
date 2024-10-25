namespace dpozoExamen.Views;

public partial class Resumen : ContentPage
{
	public Resumen(string usuario, string montoInicial, string pagoMensual, string pagoTotal, string fecha, string Pais, string Ciudad, string Nombre, string Apellido, string Edad)
	{
        InitializeComponent();
        txtUsuarioConectado.Text = "Usuario conectado: " + usuario;

        NombreLabel.Text = Nombre;
        ApellidoLabel.Text = Apellido;
        EdadLabel.Text = Edad;
        FechaLabel.Text = fecha;
        CiudadLabel.Text = Ciudad;
        PaisLabel.Text = Pais;
        MontoInicialLabel.Text = montoInicial;
        PagoMensualLabel.Text = pagoMensual;
        PagoTotalLabel.Text = pagoTotal;
    }
}