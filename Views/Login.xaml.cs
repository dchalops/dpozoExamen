namespace dpozoExamen.Views;

public partial class Login : ContentPage
{
    string[,] users = { 
                            { "estudiante", "moviles" }, 
                            { "uisrael", "2024" } 
                        };
    public Login()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        for (int i = 0; i < users.GetLength(0); i++)
        {
            if (username == users[i, 0] && password == users[i, 1])
            {
                Navigation.PushAsync(new Registro(username));
                return;
            }
        }

        DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
    }
}