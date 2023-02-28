using System;
using MediatR;
using Service.Common.Response;
using System.Threading;
using System.Threading.Tasks;
using Things.DDD.Domain.Entities;
using Things.DDD.EventHandler.Commands.Game;
using Things.DDD.EventHandler.Commands.Game.Validators;
using Things.DDD.Infrastructure;
using Things.DDD.EventHandler.User.Commands;
using Things.DDD.EventHandler.User.Commands.Validators;
using Microsoft.EntityFrameworkCore;

namespace Things.DDD.EventHandler.User
{
    public class UserLogoutEventHandler :
        IRequestHandler<UserLogoutCommand, PetitionResponse>
    {
        private readonly Context _context;
        private UserValidator _UserValidator;

        /* Constructor */
        public UserLogoutEventHandler(Context context)
        {
            _context = context;
        }

        /* Función que ejecuta el comando indicado */
        public async Task<PetitionResponse> Handle(UserLogoutCommand notification, CancellationToken cancellationToken)
        {
            try
            {
                _UserValidator = new UserValidator(_context);
                var userLogin = await _UserValidator.ExistUserID(notification.ID);
                if (userLogin == null)
                    return new PetitionResponse { success = false, message = _UserValidator.Message, module = "Users" };
                userLogin.Loggued = false;
                _context.Entry(userLogin).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new PetitionResponse { success = true, message = "Sesión cerrada", module = "Users" };
            }
            catch (Exception ex)
            {
                return new PetitionResponse { success = false, message = "No es posible loguearse: " + ex.Message, module = "Users" };
            }
        }
    }
}
