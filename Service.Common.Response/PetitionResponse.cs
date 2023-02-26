using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Common.Response
{
    public class PetitionResponse
    {
        /* Variable que indica el estado de la respuesta. */
        public bool success { get; set; }
        /* Variable que indica el mensaje de la respuesta. */
        public string message { get; set; }
        /* Variable que indica el modulo de donde se genera la respuesta. */
        public string module { get; set; }
        /* Variable que indica el Objeto de la respuesta. */
        public object result { get; set; }
    }
}
