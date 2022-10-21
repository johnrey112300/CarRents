using CarRent.Model;

namespace CarRent;

public partial class MainPage : ContentPage
{
	Cars cars = new Cars();
	public MainPage()
	{
		InitializeComponent();
	}
    private async void btnregister_Clicked(object sender, EventArgs e)
    {
        var result = await cars.AddCar(txtCname.Text, txtPnum.Text, txtSitCap.Text, txtCondition.Text, txtStatus.Text);
        if (result == true)
        {
            await DisplayAlert("Register", "Data Succesfully Saved", " OK!");
        }
        else
        {
            //IC_check();
            await DisplayAlert("Register", "Data Not Registered or your Email is already Exist or No Internet Connection", " OK!");
        }
    }


    private async void btncancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}

