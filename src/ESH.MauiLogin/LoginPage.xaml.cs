using ESH.MauiLogin.Pages.Home;

namespace ESH.MauiLogin;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void btnLogar_Clicked(object sender, EventArgs e)
    {
        if (txtUsuario.Text.Equals("edmilson.hora") && txtSenha.Text.Equals("senha@123"))
        {
            Preferences.Default.Set<bool>("mantemLogado", chkMantemLogado.IsChecked);
            await Navigation.PushModalAsync(new NavigationPage(new HomePage()));
        }
        else
        {
            await DisplayAlert("Login", "Usuario ou Senha Invalido", "OK");
        }
    }

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        if (Preferences.Default.Get<bool>("mantemLogado", false))
        {
            await Navigation.PushModalAsync(new NavigationPage(new HomePage()));
        }
    }

}