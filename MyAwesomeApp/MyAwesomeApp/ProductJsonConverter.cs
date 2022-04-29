//using APISerializationExample.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyAwesomeApp.Models;

namespace MyAwesomeApp
{
    public class ProductJsonConverter : JsonCreationConverter<Item>
    {
        protected override Item Create(Type objectType, JObject jObject)
        {
            if (jObject == null) throw new ArgumentNullException("jObject");

            if (jObject["start"] != null || jObject["Start"] != null)
            {
                return new CalendarAppointment();
            }
            else if (jObject["isCompleted"] != null || jObject["IsCompleted"] != null)
            {
                return new MyAwesomeApp.Models.Task();
            }
            else
            {
                return new Item();
            }
        }
    }
}
