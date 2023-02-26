using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Things.DDD.Domain.DTOs
{
    public class CompanyDTO
    {
        /* Llave que indica el número interno del la empresa */
        public Guid ID { get; set; }

        /* Variable que indica el número interno de la empresa */
        public int IDNum { get; set; }

        /* Variable que indica el nombre de la empresa. */
        public string Name { get; set; }

        /* Variable que indica la descripción de la empresa. */
        public string Description { get; set; }

        /* Variable que indica el numero de celular. */
        public string CellNumber { get; set; }

        /* Variable que indica el numero de celular2. */
        public string CellNumber2 { get; set; }

        /* Variable que indica el email. */
        public string EmailAddress { get; set; }

        /* Variable que indica la ciudad */
        public Guid? City { get; set; }

        /* Variable que indica el departamento. */
        public Guid? State { get; set; }

        /* Variable que indica el pais. */
        public Guid? Country { get; set; }

        /* Variable que indica el pais. */
        public byte[] Logo { get; set; }

        /* Variable que indica el pais. */
        public Guid Plan { get; set; }

        #region System Fields
        /* Variable que indica si el registro está Activo o Inactivo. */
        public bool Inactive { get; set; }

        /* Variable que indica la fecha en la que se crea el registro. */
        public DateTime CreatedAt { get; set; } = new DateTime();

        /* Variable que indica la fecha en la que se modifica el registro. */
        public DateTime ModifyDate { get; set; } = new DateTime();

        /* Variable que indica el usuario que modifica el registro. */
        public string ModifiedBy { get; set; }

        /* Variable que indica el usuario que crea el registro. */
        public string CreatedBy { get; set; }

        #endregion
    }
}
