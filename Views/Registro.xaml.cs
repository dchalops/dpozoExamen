namespace dpozoExamen.Views;

public partial class Registro : ContentPage
{
    string connectedUser;
    decimal pagoMensual;
    decimal montoInicial;
    public Registro(string username)
	{
        InitializeComponent();
        connectedUser = username;
        txtUsuarioConectado.Text = "Usuario conectado: " + connectedUser;

        /*MontoInicialEntry.TextChanged += (s, e) =>
        {
            if (decimal.TryParse(MontoInicialEntry.Text, out decimal montoInicial))
            {
                decimal pagoMensual = (1500 - montoInicial) / 4 * 1.04m;
                PagoMensualEntry.Text = pagoMensual.ToString("F2");
            }
        };*/
    }

    private void OnCalcularPagoClicked(object sender, EventArgs e)
    {
        if (decimal.TryParse(MontoInicialEntry.Text, out montoInicial))
        {
            if (montoInicial < 1 || montoInicial > 1499)
            {
                DisplayAlert("Error", "El monto inicial debe estar entre 1 y 1499", "OK");
                return;
            }
        }
        else
        {
            DisplayAlert("Error", "Ingrese un monto inicial válido", "OK");
            return;
        }   

        decimal porcentaje = 1500 * 0.04m;
        pagoMensual = (1500 - montoInicial) / 4 + porcentaje;
        PagoMensualEntry.Text = pagoMensual.ToString("F2");

        
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (PaisPicker.SelectedIndex == -1)
        {
            DisplayAlert("Error", "Debe seleccionar País", "OK");
            return;
        }
        
        if (CiudadPicker.SelectedIndex == -1)
        {
            DisplayAlert("Error", "Debe seleccionar Ciudad", "OK");
            return;
        }
        
        if (string.IsNullOrEmpty(txtNombre.Text))
        {
            DisplayAlert("Error", "Debe ingresar Nombre", "OK");
            return;
        }
        
        if (string.IsNullOrEmpty(txtApellido.Text))
        {
            DisplayAlert("Error", "Debe ingresar Apellido", "OK");
            return;
        }
        
        if (string.IsNullOrEmpty(txtEdad.Text))
        {
            DisplayAlert("Error", "Debe ingresar Edad", "OK");
            return;
        }
        
        if (FechaPicker.Date < DateTime.Now)
        {
            DisplayAlert("Error", "La fecha debe ser mayor a la actual", "OK");
            return;
        }
        
        decimal pagoTotal = pagoMensual * 4 + montoInicial;

        Navigation.PushAsync(new Resumen(connectedUser, MontoInicialEntry.Text, PagoMensualEntry.Text, pagoTotal.ToString(), FechaPicker.Date.ToString("dd-MM-yyyy"), PaisPicker.SelectedItem.ToString(), CiudadPicker.SelectedItem.ToString(), txtNombre.Text, txtApellido.Text, txtEdad.Text));
    }

}