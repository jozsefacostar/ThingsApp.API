using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Things.History.DDD.Domain.Entities
{
    public class GameHistory
    {
        /* Constructor */

        /* Llave que indica el número interno del partido */
        [Key]
        [Column(Order = 0)]
        public Guid ID { get; set; }

        /* Variable que indica la descripción del partido. */
        [StringLength(200, ErrorMessage = "La longitud máxima de la descrición del partido es  200")]
        public Guid TeamA { get; set; }

        /* Variable que indica la descripción del partido. */
        [StringLength(200, ErrorMessage = "La longitud máxima de la descrición del partido es  200")]
        public Guid TeamB { get; set; }

        /* Variable que indica los goles del equipo A. */
        [StringLength(200, ErrorMessage = "La longitud máxima de la descrición del partido es  200")]
        public int GoalsA { get; set; }

        /* Variable que indica los goles del equipo B. */
        [StringLength(200, ErrorMessage = "La longitud máxima de la descrición del partido es  200")]
        public int GoalsB { get; set; }

        /* Variable que indica la fecha en la que inicia el partido. */
        public DateTime DateInitial { get; set; } = new DateTime();

        /* Variable que indica la fecha en la que finaliza el partido. */
        public DateTime DateFinal { get; set; } = new DateTime();

        /* Variable que indica si el partido ha finalizado. */
        public bool Finalized { get; set; }


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
