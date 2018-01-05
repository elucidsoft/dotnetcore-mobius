using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dotnetcore_mobius.responses
{
    public static class JsonSingleton
    {
        public static T GetInstance<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }
    }

}
