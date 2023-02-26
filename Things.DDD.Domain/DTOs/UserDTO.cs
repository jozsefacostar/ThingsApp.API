using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Things.DDD.Domain.DTOs
{
    public class UserDTO
    {
        public UserDTO()
        {
            RecordBets = new HashSet<RecordBetDTO>();
        }

        /* Llave que indica el número interno del perfil */
        public Guid ID { get; set; }

        /* Variable que indica el nombre del usuario. */
        public string Name { get; set; }

        /* Variable que indica el número de documento del usuario. */
        public string DocumentNumber { get; set; }

        /* Variable que indica la contraseña del usuario. */
        public string Password { get; set; }

        /* Variable que indica si el usuario está logueado o no. */
        public bool Loggued { get; set; }

        /* Variable que indica el identificador del Perfil */
        public Guid Profile { get; set; }

        /* Variable que indica la propiedad de navegación entre perfil y Usuario. */
        public virtual ProfileDTO ProfileNavigation { get; set; }

        /* Colección de usuarios desde registros de apuestas */
        public virtual ICollection<RecordBetDTO> RecordBets { get; set; }

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
