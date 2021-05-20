using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace hw20
{
    /// <summary>
    /// класс расширения для использования переменных сессии
    /// </summary>
    public static class SessionExtensions
    {

        /// <summary>
        /// задать значение переменной
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Set<T>(this ISession session, string key, T value)
        {            

            var x = JsonConvert.SerializeObject(value);
            session.SetString(key, x);
        }

        /// <summary>
        /// прочитать значение переменной
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
