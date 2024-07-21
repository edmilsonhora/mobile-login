using ESH.MauiLogin.BackEnd;
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
       await CopiarSeNaoExiste();

        ValidarAcessoDb();
       
        if(AutenticarUsuario(txtUsuario.Text, txtSenha.Text))
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

    private void ValidarAcessoDb()
    {
        using (var db = new MyContext())
        {
            var r = db.Usuarios.FirstOrDefault(p => p.Nome == "edmilson.hora");
            if (r == null)
            {
                db.Add(new Usuario() { Nome = "edmilson.hora", Senha = "senha@1234" });
                db.SaveChanges();
            }
        }
    }

    private bool AutenticarUsuario(string usuario, string senha)
    {
        using (var db = new MyContext())
        {
            return db.Usuarios.Count(p => p.Nome == usuario && p.Senha == senha) > 0;
        }
    }
    private async Task CopiarSeNaoExiste()
    {
        if (File.Exists(Path.Combine(FileSystem.Current.AppDataDirectory, "myLogin.db"))) return;


        // Abra o arquivo de origem usando Stream
        using Stream inputStream = await FileSystem.Current.OpenAppPackageFileAsync("myLogin.db");

        // Crie um nome de arquivo de destino
        string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, "myLogin.db");

        // Copie o arquivo para o AppDataDirectory
        using FileStream outputStream = File.Create(targetFile);
        await inputStream.CopyToAsync(outputStream);
    }

}