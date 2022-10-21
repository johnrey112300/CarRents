using CarRent.Model;

namespace CarRent.Pages;


public partial class AdminPage : ContentPage
{
    private Admin add = new();
	public AdminPage()
	{
		InitializeComponent();
	}
    private async void btnsave_Clicked(object sender, EventArgs e)
    {
        await add.AddAdmin(entryemail.Text, entrypass.Text);
        await DisplayAlert("Succefully Added", "The Customer Has Added", "Got It!");
    }

}