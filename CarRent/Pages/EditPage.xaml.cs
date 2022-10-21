namespace CarRent.Pages;

using CarRent.Model;
using static CarRent.App;

public partial class EditPage : ContentPage
{
	private Cars car = new();
	public EditPage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		entryCname.Text = CarNames;
		entryCond.Text = condition;
		entrystat.Text = sstatus;
    }
	 

    private async void btnmodify_Clicked(object sender, EventArgs e)
	{
        if (!string.IsNullOrEmpty(entryCname.Text) || string.IsNullOrEmpty(entryCname.Text))
				{
			var a = await car.EditData(entryCname.Text, entryCond.Text, entrystat.Text);
			if (!a)
				await DisplayAlert("Modify", "Data Succesfully Updated", "Got It!");
			await Navigation.PopAsync();
			return;
				}
		await DisplayAlert("Modify", "Not Succesfully Updated", "Retry!");
    }
}