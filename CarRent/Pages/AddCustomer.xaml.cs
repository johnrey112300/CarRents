using CarRent.Model;
using static CarRent.App;

namespace CarRent.Pages;

public partial class AddCustomer : ContentPage
{
    private Coustomer coust = new();
    public AddCustomer()
	{
		InitializeComponent();

	}

	private async void btnsave_Clicked(object sender, EventArgs e)
	{
		await coust.AddCoustomer(key, entryFirstname.Text, entryLastname.Text, entryAddress.Text, entryPhonenumber.Text);
		await DisplayAlert("Succefully Added", "The Customer Has Added", "Got It!");
    }
}