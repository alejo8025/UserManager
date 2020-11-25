using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManager.Domain.Helper
{
    public static class Tools
    {
        public static async Task<List<string>> ConvertStringToList(string Data, char Separator)
        {
            var result = Data.Split(Separator).ToList();
            return await Task.FromResult(result);
        }

        public static async Task<bool> ExistIn(List<string> ListData, string ObjSearch)
        {
            var Result = ListData.FirstOrDefault(x => x.Trim().ToLower() == ObjSearch.Trim().ToLower());
            if (string.IsNullOrEmpty(Result))
            {
                return await Task.FromResult(false);
            }
            return await Task.FromResult(true);
        }


        public static DateTime ConvertStringToDateTime(string Date, string Time)
        {
            Date = (Date.Length < 6) ? Date.PadLeft(6, '0') : Date;
            Time = (Time.Length < 4) ? Time.PadLeft(4, '0') : Time;
            var data = String.Format("{1}/{0}/{2}", Date.Substring(0, 2), Date.Substring(2, 2), Date.Substring(4, 2));
            var time = String.Format("{0}:{1}", Time.Substring(0, 2), Time.Substring(2, 2));
            string dateTime = String.Format("{0} {1}", data, time);
            return DateTime.Parse(dateTime);

        }

        public static bool ComparedDate(DateTime fechaInicial, DateTime FechaActial)
        {
            return (DateTime.Compare(fechaInicial, FechaActial) < 0);
        }

        public static bool ContainIn(List<string> ListData, string ObjSearch)
        {

            foreach (var item in ListData)
            {
                if (ObjSearch.Contains(item))
                    return true;

            }

            return false;
        }
    }
}
