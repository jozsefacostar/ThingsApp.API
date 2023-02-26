using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Service.Common.Mapping
{
    /* Clase que permite mapear los Dtos */
    public static class DtoMapperExtension
    {
        public static T MapTo<T>(this object value)
        {
            return JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(value));
        }
    }
}
