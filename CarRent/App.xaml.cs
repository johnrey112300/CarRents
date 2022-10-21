
using Firebase.Database;
using CarRent.Pages;
namespace CarRent;

public partial class App : Application
{
	public static FirebaseClient car = new FirebaseClient("https://carrent-98efa-default-rtdb.asia-southeast1.firebasedatabase.app/");
	public static string CarNames, PlateNums, SitCapacitys, condition,sstatus, key, Firstname, Lastname, ADdress, phoneNumber;
    public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new Pages.AdminPage());
	}	
}
