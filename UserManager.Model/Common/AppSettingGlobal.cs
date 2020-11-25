using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace UserManager.Model.Common
{
    public class AppSettingGlobal
    {
        private AppSetting ListSettings { get; set; }
        public AppSettingGlobal(IOptions<AppSetting> settings)
        {
            ListSettings = settings.Value;
        }

        public string GetValue(string Key)
        {
            try
            {
                var properties = ListSettings.GetType();
                PropertyInfo value = properties.GetProperty(Key);
                return value.GetValue(ListSettings, null).ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object GetModelValue(string Key)
        {
            try
            {
                var properties = ListSettings.GetType();
                PropertyInfo value = properties.GetProperty(Key);
                return value.GetValue(ListSettings, null);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<T> GetValueModelTask<T>(string Key)
        {
            var properties = ListSettings.GetType();
            PropertyInfo value = properties.GetProperty(Key);
            dynamic result = value.GetValue(ListSettings, null);
            var jsonstring = JsonConvert.SerializeObject(result);
            var json = JsonConvert.DeserializeObject<T>(jsonstring);
            return Task.FromResult(json);
        }
    }
}
