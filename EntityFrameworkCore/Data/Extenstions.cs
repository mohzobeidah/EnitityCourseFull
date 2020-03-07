using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Data
{
    public static class Extenstions
    {
        public static string ToJson(this object value, Formatting formatting = Formatting.None)
        {
            if (value == null) return null;
            try
            {
                return JsonConvert.SerializeObject(value, formatting);
                
            }
            catch 
            {
                //log exception but dont throw one
                return  new Exception ().Message;
            }
        }
        public static T FromJson<T>(this string value) where T : class
        {
            if (value == null) return null;
            try
            {
                return JsonConvert.DeserializeObject<T>(value);

            }
            catch
            {
                //log exception but dont throw one
                return null;
            }
        }
    }
}
