using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Things.DDD.Infrastructure;
using Things.DDD.Domain.Entities;

namespace Things.DDD.EventHandler.User.Commands.Validators
{
    public class UserValidator
    {
        private readonly Context _context;
        public string Message { get; set; }
        public UserValidator(Context context)
        {
            _context = context;
        }

        /* Función que permite validar si las credenciales son correctas */
        public async Task<Things.DDD.Domain.Entities.User> ValidLogin(string NIT, string Pass)
        {
            var user = await
               _context.Users
               .Include(x => x.ProfileNavigation)
               .Where(x => (x.DocumentNumber.Equals(NIT) && x.Password.Equals(Pass)))
               .FirstOrDefaultAsync();
            if (user == null)
            {
                Message = "Las credenciales ingresadas no son correctas";
                return null;
            }
            return user;
        }

        /* Función que permite validar si existe el user con el ID */
        public async Task<Things.DDD.Domain.Entities.User> ExistUserID(string ID)
        {
            var user = await
               _context.Users
               .Include(x => x.ProfileNavigation)
               .Where(x => (x.ID.Equals(Guid.Parse(ID))))
               .FirstOrDefaultAsync();
            if (user == null)
            {
                Message = "El usuario logueado no existe";
                return null;
            }
            return user;
        }
    }
}
