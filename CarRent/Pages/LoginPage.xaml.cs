using CarRent.Model;

namespace CarRent.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void btnsignup_Clicked_1(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new AdminPage());
    }


	private async void btnlogin_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new WelcomePage());
    }

}