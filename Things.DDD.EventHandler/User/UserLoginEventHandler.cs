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
    public class UserLoginEventHandler :
        IRequestHandler<UserLoginCommand, PetitionResponse>
    {
        private readonly Context _context;
        private UserValidator _UserValidator;

        /* Constructor */
        public UserLoginEventHandler(Context context)
        {
            _context = context;
        }

        /* Función que ejecuta el comando indicado */
        public async Task<PetitionResponse> Handle(UserLoginCommand notification, CancellationToken cancellationToken)
        {
            try
            {
                _UserValidator = new UserValidator(_context);
                var userLogin = await _UserValidator.ValidLogin(notification.NIT, notification.Pass);
                if (userLogin == null)
                    return new PetitionResponse { success = false, message = _UserValidator.Message, module = "Users" };
                userLogin.Loggued = true;
                _context.Entry(userLogin).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                //Objetc dynamic
                dynamic Persona1 = new System.Dynamic.ExpandoObject();
                //le añado algunas propiedades
                Persona1.ID = userLogin.ID;
                Persona1.Name = userLogin.Name;
                Persona1.ProfileCode = userLogin.ProfileNavigation.Code;
                return new PetitionResponse { success = true, message = "Login exitoso", module = "Users", result = Persona1 };
            }
            catch (Exception ex)
            {
                return new PetitionResponse { success = false, message = "No es posible loguearse: " + ex.Message, module = "Users" };
            }
        }
    }
}
