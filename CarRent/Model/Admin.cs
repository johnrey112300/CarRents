using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using static CarRent.App;



namespace CarRent.Model
{
    public class Admin
    {
    
        public string Emails { get; set; }
        public string Password { get; set; }


        public async Task<bool> AddAdmin( string mails, string pword)
        {
            try
            {
                var evaluateEmail = (await car.Child("Admin")
                    .OnceAsync<Admin>())
                    .FirstOrDefault(a => a.Object.Emails == mails);

                if (evaluateEmail == null)
                {
                    var user = new Admin()
                    {
                     
                        Emails = mails,
                        Password = pword
                    };
                    await car
                        .Child("Admin")
                        .PostAsync(user);
                    car.Dispose();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UserLogin(string emails, string Pass)
        {
            try
            {
                var evaluateEmail = (await car.Child("Admin")
                                  .OnceAsync<Admin>())
                                  .FirstOrDefault
                                  (a => a.Object.Emails == emails &&
                                   a.Object.Password == Pass);
                return evaluateEmail != null;
            }
            catch
            {
                return false;
            }
        }
    }
}
