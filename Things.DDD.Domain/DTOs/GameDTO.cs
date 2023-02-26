using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Things.DDD.Domain.DTOs
{
    public class GameDTO
    {
        /* Constructor */
        public GameDTO()
        {
            this.SessionBets = new HashSet<SessionBetDTO>();
        }

        /* Llave que indica el número interno del partido */
        public Guid ID { get; set; }

        /* Variable que indica la descripción del partido. */
        public Guid TeamA { get; set; }

        /* Variable que indica la descripción del partido. */
       public Guid TeamB { get; set; }

        /* Variable que indica los goles del equipo A. */
        public int GoalsA { get; set; }

        /* Variable que indica los goles del equipo B. */
       public int GoalsB { get; set; }

        /* Variable que indica la fecha en la que se jugará el partido. */
        public DateTime DateGame { get; set; } = new DateTime();

        /* Variable que indica si el partido ha finalizado. */
        public bool Finalized { get; set; }

        /* Variable que indica la navegation del equipo A. */
        public virtual TeamDTO TeamANavigation { get; set; }

        /* Variable que indica la navegation del equipo A. */
        public virtual TeamDTO TeamBNavigation { get; set; }

        /* Colección de usuarios desde sesión */
        public virtual ICollection<SessionBetDTO> SessionBets { get; set; }

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
