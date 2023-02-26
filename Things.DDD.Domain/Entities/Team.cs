using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Things.DDD.Domain.Entities
{
    public class Team
    {

        /* Constructor */
        public Team()
        {

            TeamsA = new HashSet<Game>();
            TeamsB = new HashSet<Game>();
        }

        /* Llave que indica el número interno del la equipo */
        [Key]
        [Column(Order = 0)]
        public Guid ID { get; set; }

        /* Variable que indica la descripción de la equipo. */
        [StringLength(200, ErrorMessage = "La longitud máxima de la descrición del equipo es  200")]
        public string Description { get; set; }

        /* Variable que indica colección de Equipos A */
        public virtual ICollection<Game> TeamsA { get; set; }

        /* Variable que indica colección de Equipos B */
        public virtual ICollection<Game> TeamsB { get; set; }

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
