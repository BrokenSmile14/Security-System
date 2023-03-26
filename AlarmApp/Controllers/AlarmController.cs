using AlarmApp.Data;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;

namespace AlarmApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmController : ControllerBase
    {
        private readonly DataDbContext dataDbContext;

        public AlarmController(DataDbContext dataDbContext)
        {
            this.dataDbContext = dataDbContext;
        }

        [HttpGet]
        public async Task Get(int zoneId, bool isAlarm)
        {
            if (isAlarm)
            {
                dataDbContext.Alarms.Add(new Alarm { Id = zoneId });

                var tlClient = new TelegramBotClient("token");
                await tlClient.SendTextMessageAsync(12345, $"Alarm in {zoneId}");

            }
        }

        [HttpGet]
        public IEnumerable<Alarm> GetAll()
        {
            return dataDbContext.Alarms.ToList();
        }
    }
}
