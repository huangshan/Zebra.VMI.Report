using System;
using System.Configuration;

namespace Zebra.VMI.Report.Common
{
    public class ConfigMgr
    {
        public static string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static string GetSettingByName(string name)
        {
            return GetSettingByName<string>(name);
        }

        public static T GetSettingByName<T>(string name)
        {
            var keyValue = ConfigurationManager.AppSettings[name];
            return (T)Convert.ChangeType(keyValue, typeof(T));
        }

        public static T GetSettingByName<T>(string name, T defaultValue)
        {
            var keyValue = ConfigurationManager.AppSettings[name];
            T result;

            try
            {
                result = (T)Convert.ChangeType(keyValue, typeof(T));
            }
            catch
            {
                result = defaultValue;
            }

            if (result == null)
                result = defaultValue;

            return result;
        }
    }
}
