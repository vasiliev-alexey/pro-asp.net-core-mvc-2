namespace SportsStore.Infrastructure
{
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;



    /// <summary>
    /// The session extenssion.
    /// </summary>
    public static class SessionExtenssion
    {

        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null
                       ? default : JsonConvert.DeserializeObject<T>(sessionData);
        }


    }
}