using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using Firebase.Database;
using static CarRent.App;
using System.Collections.ObjectModel;
//using Android.Graphics;
//using Java.Lang;

namespace CarRent.Model
{
    public class Coustomer
    {
        public string Firstnames { get; set; }
        public string LastNames { get; set; }
        public string Addresss{ get; set; }
        public string PhoneNumbers { get; set; }
    


        public async Task<bool> AddCoustomer(string userkey, string fname, string lname, string add, string pnum)
        {
            try
            {
                var work = new Coustomer()
                {
                    Firstnames = fname,
                    LastNames = lname,
                    Addresss = add,
                    PhoneNumbers = pnum
                };
                await car
                    .Child($"Cars/{userkey}/Coustomer")
                    .PostAsync(work);
                car.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<string> GetCustomerKey(string fname)
        {
            try
            {
                var getcostkey = (await car.Child("Coustomer").OnceAsync<Coustomer>()).
                    FirstOrDefault(a => a.Object.Firstnames == fname);
                if (getcostkey == null) return null;
                Firstname = getcostkey.Object.Firstnames;
                Lastname = getcostkey.Object.LastNames;
                ADdress = getcostkey.Object.Addresss;
                phoneNumber = getcostkey.Object.PhoneNumbers;
           
                return getcostkey?.Key;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public ObservableCollection<Coustomer> GetCustomerList()
        {
            var costlist = car
                 .Child("Coustomer")
                .AsObservable<Coustomer>()
                .AsObservableCollection();
            return costlist;

        }
    }
}
