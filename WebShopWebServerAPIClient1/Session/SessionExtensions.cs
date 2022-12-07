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
    }
}
