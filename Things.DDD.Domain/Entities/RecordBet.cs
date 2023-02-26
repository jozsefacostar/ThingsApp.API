using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Things.DDD.Domain.Entities
{
    public class RecordBet
    {

        /* Llave que indica el número interno de la sesión */
        [Key]
        [Column(Order = 0)]
        public Guid ID { get; set; }

        /* Variable que indica la descripción del sesión. */
        public Guid SessionBet { get; set; }

        /* Variable que indica la descripción del sesión. */
        public Guid User { get; set; }

        /* Variable que indica los goles apostados para el equipo A */
        public int GoalsA { get; set; }

        /* Variable que indica los goles apostados para el equipo A */
        public int GoalsB { get; set; }

        /* Variable que indica la navegation del equipo A. */
        public virtual SessionBet SessionBetNavigation { get; set; }

        /* Variable que indica la navegation del equipo A. */
        public virtual User UserNavigation { get; set; }

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


