using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace WebShop.Session
{
    public static class SessionExtensions
    {

        //convert from object to binary
        public static void SetJson(this ISession session, string key, object value)
        {//Set the given key and value in the current session. 
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        //covnert from binary to object
        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            //null return default
            return sessionData == null ? default : JsonConvert.DeserializeObject<T>(sessionData);
        }

        public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonConvert.SerializeObject(value); 
    }

        public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            object o;
            tempData.TryGetValue(key, out o);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }
    }
}
