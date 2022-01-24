namespace LogYourself.Models
{
    public class OccuranceModel
    {
        public DateTime Time { get; set; }
        public double Ammount { get; set; }
        public string Unit { get; set; }

        public OccuranceModel(DateTime time, double ammount)
        {
            Time = time;
            Ammount = ammount;
        }
    }
}