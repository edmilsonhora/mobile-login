
namespace ESH.MauiLogin.Pages.Home;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    protected override bool OnBackButtonPressed()
    {
        Application.Current?.Quit();
        return false;
    }
    private async void btnGoUsuarios_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.Usuarios.ListPage());
    }

    private async void btnDeslogar_Clicked(object sender, EventArgs e)
    {
        var result = await DisplayAlert("Sair do App", "Deseja sair do App?", "SIM", "NÃO");

        if (result)
        {
            Preferences.Default.Remove("mantemLogado");
            Application.Current?.Quit();
        }


    }

}