using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarRent.App;
using Firebase.Database;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
//using Android.Graphics;
//using static Android.Provider.UserDictionary;

namespace CarRent.Model
{
    public class Cars
    {
        public string CarName { get; set; }
        public string PlateNum  { get; set; }
        public string SitCapacity { get; set; }
        public string condition { get; set; }
        public string status { get; set; }

        public async Task<bool> AddCar(string Cname, string Pnum, string Sitcap, string Cond, string stat)
        {
            try
            {
                var evaluateCarname = (await car.Child("Cars")
                    .OnceAsync<Cars>())
                    .FirstOrDefault(a => a.Object.CarName == Cname);

                if (evaluateCarname == null)
                {
                    var user = new Cars()
                    {
                        CarName = Cname,
                        PlateNum = Pnum,
                        SitCapacity = Sitcap,
                        condition = Cond,
                        status = stat
                    };
                    await car
                        .Child("Cars")
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


        //public async Task<bool> UserLogin(string Cname, string Cond)
        //{
        //    try
        //    {   
        //        var evaluateCarName = (await car.Child("Users")
        //                          .OnceAsync<Cars>())
        //                          .FirstOrDefault
        //                          (a => a.Object.CarName == Cname &&
        //                           a.Object.condition ==Cond);
        //        return evaluateCarName != null;
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //}
        public async Task<string> GetCarsKey(string Cname)
        {
            try
            {
                var getuserkey = (await car.Child("Cars").OnceAsync<Cars>()).
                    FirstOrDefault(a => a.Object.CarName == Cname);
                if (getuserkey == null) return null;
                CarNames = getuserkey.Object.CarName;
                SitCapacitys =getuserkey.Object.SitCapacity;
                PlateNums = getuserkey.Object.PlateNum;
                condition = getuserkey.Object.condition;
                sstatus = getuserkey.Object.status;

                return getuserkey?.Key;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public ObservableCollection<Cars> GetCarsList()
        {
            var userlist = car
                 .Child("Cars")
                .AsObservable<Cars>()
                .AsObservableCollection();
            return userlist;

        }


        public async Task<bool> EditData(string Cname, string Cond, string stat)
        {
            try
            {
                var evaluateCars = (await car
                    .Child("Cars")
                    .OnceAsync<Cars>()).FirstOrDefault
                    (a => a.Object.CarName == Cname);
                if (evaluateCars != null)
                {
                    Cars user = new Cars
                    {
                        CarName = Cname,
                        PlateNum = PlateNums,
                        SitCapacity = SitCapacitys,
                        status = stat,
                        condition = Cond
                    };
                    await car
                        .Child("Cars")
                        .Child(key)
                        .PatchAsync(user);
                    car.Dispose();
                    return true;
                }
                car.Dispose();
                return false;

            }
            catch (Exception)
            {
                car.Dispose();
                return false;
            }
        }

        public async Task<string> DeleteData()
        {
            try
            {
                //Remove data from Users' node
                await car
                    .Child($"Cars/{key}")
                    .DeleteAsync();
                return "Removed";
            }
            catch (Exception)
            {
                return "error";
            }
        }
    }
}