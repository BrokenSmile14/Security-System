using AlarmApp.Data;
using Microsoft.AspNetCore.Mvc;

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
        public void Get(int zoneId, bool isAlarm)
        {
            if (isAlarm)
            {
                dataDbContext.Alarms.Add(new Alarm { Id = zoneId });

            }
        }

        [HttpGet]
        public IEnumerable<Alarm> GetAll()
        {
            return dataDbContext.Alarms.ToList();
        }
    }
}
