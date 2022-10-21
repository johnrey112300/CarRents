using CarRent.Model;


namespace CarRent.Pages;

public partial class HomePage : ContentPage
{
    private Cars carslist = new();
    public HomePage()
    {
        InitializeComponent();
        ListCars.ItemsSource = carslist.GetCarsList();
    }

    private async void ListUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        App.CarNames = (e.CurrentSelection.FirstOrDefault() as Cars)?.CarName;
        App.key = await carslist.GetCarsKey(App.CarNames);
        //await Navigation.PushAsync(new EditPage());

    }

    private async void edititem_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(App.key))
        {
            await Navigation.PushAsync(new EditPage());
        }
        else
        {
            await DisplayAlert("Data", "Please Select a Data to modify! ", "Got it!");
        }
    }

    private async void deletitem_Clicked(object sender, EventArgs e)
    {
        var result = await DisplayAlert("Remove", "Do you want to remove this data?", "Yes", "No");
        if (result)
        {
            await carslist.DeleteData();
        }
    }
    private async void addrenter_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(App.key))
        {
            await Navigation.PushAsync(new AddCustomer());
        }
        else
        {
            await DisplayAlert("Data", "Please Select a Data to add thier coustomer! ", "Got it!");
        }

    }


}