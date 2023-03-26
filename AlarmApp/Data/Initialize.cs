using Microsoft.EntityFrameworkCore;

namespace AlarmApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(this DataDbContext context)
        {
            if (!context.Database.EnsureCreated())
            {
                context.Database.Migrate();
            }
            AddSeedData(context);

            context.SaveChanges();
        }

        private static void AddSeedData(DataDbContext context)
        {
            if (!context.Alarms.Any())
            {
                var session = new Alarm()
                {
                    TriggerTimeUtc = DateTime.UtcNow,
                    ZoneId = 1
                };

                context.Alarms.Add(session);

                context.SaveChanges();
            }
        }
    }
}
