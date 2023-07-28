namespace MauiApp4.Pages.Usuarios;

public partial class ListPage : ContentPage
{
    public ListPage()
    {
        InitializeComponent();
    }

    private async void btnGoEdit_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.Usuarios.EditPage());
    }
}