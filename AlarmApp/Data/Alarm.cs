namespace AlarmApp.Data
{
    public class Alarm
    {
        public int Id { get; set; }

        public DateTime TriggerTimeUtc { get; set; }

        public int ZoneId { get; set; }
    }
}
