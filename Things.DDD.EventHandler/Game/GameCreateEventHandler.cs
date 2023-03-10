using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Service.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Things.DDD.Domain.Entities;
using Things.DDD.EventHandler.Commands.Game;
using Things.DDD.EventHandler.Commands.Game.Validators;
using Things.DDD.EventHandler.HubConfig;
using Things.DDD.Infrastructure;

namespace Things.DDD.EventHandler.Games
{
    public class GameCreateEventHandler :
        IRequestHandler<GameCreateCommand, PetitionResponse>
    {
        private readonly Context _context;
        private GameValidators _gameValidator;
        private readonly IHubContext<AddGameHub> _hub;

        /* Constructor */
        public GameCreateEventHandler(Context context, IHubContext<AddGameHub> hub)
        {
            _context = context;
            _hub = hub;
        }

        /* Función que ejecuta el comando indicado */
        public async Task<PetitionResponse> Handle(GameCreateCommand notification, CancellationToken cancellationToken)
        {
            try
            {
                _gameValidator = new GameValidators(_context);
                if (!await _gameValidator.ExistDateCrossing(notification.TeamA, notification.TeamB, notification.DateInitial))
                    return new PetitionResponse { success = false, message = _gameValidator.Message, module = "Games" };

                if (!await _gameValidator.IsTodayGame(notification.DateInitial))
                    return new PetitionResponse { success = false, message = _gameValidator.Message, module = "Games" };

                await _context.AddAsync(new Game() { ID = Guid.NewGuid(), TeamA = notification.TeamA, TeamB = notification.TeamB, GoalsA = 0, GoalsB = 0, Inactive = false, CreatedAt = DateTime.Now, CreatedBy = "MANAGER", DateInitial = notification.DateInitial, DateFinal = notification.DateInitial.AddHours(2) });
                await _context.SaveChangesAsync();

                var teamA = await _context.Teams.Where(x => x.ID.Equals(notification.TeamA)).FirstOrDefaultAsync();
                var teamB = await _context.Teams.Where(x => x.ID.Equals(notification.TeamB)).FirstOrDefaultAsync();

                var dateGame = "Partido creado: (" + teamA.Description + " VS " + teamB.Description + ") " + notification.DateInitial;
                await _hub.Clients.All.SendAsync("TransferAddGameData", dateGame);
                await IntegrationMicroservicesHistory(notification);

                return new PetitionResponse { success = true, message = "Partido creado con éxito", module = "Games" };
            }
            catch (Exception ex)
            {
                return new PetitionResponse { success = false, message = "No es posible crear partido: " + ex.Message, module = "Games" };
            }
        }
        /* Función que se comunica con microservicio de History */
        private async Task IntegrationMicroservicesHistory(GameCreateCommand GameCreateCommand)
        {
            try
            {
                var json = JsonConvert.SerializeObject(GameCreateCommand);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "http://localhost:20945/api/GameHistory";
                using var client = new HttpClient();
                var response = await client.PostAsync(url, data);
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                new PetitionResponse { success = false, message = "No es posible crear partido historico: " + ex.Message, module = "Games" };
            }
        }
    }
}
