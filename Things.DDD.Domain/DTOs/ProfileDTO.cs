using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Things.DDD.Domain.DTOs
{
    public class ProfileDTO
    {
        /* Constructor */
        public ProfileDTO()
        {
            this.Users = new HashSet<UserDTO>();
        }

        /* Llave que indica el número interno del perfil */
       public Guid ID { get; set; }

        /* Variable que indica la descripción de la perfil. */
        public string Name { get; set; }

        /* Colección de usuarios desde Perfil */
        public virtual ICollection<UserDTO> Users { get; set; }

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
