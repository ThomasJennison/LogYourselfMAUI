using LogYourself.Models.Base;
using System;

namespace LogYourself.Models
{
    public class SocializationModel : LogModelBase, IModel
    {
        public string SocializationType { get; set; }
        public string Location { get; set; }
        public string Comments { get; set; }
        public double Enjoyment { get; set; }
        public double Duration { get; set; }
        public bool WantedToSocialize { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public SocializationModel() : base(ModelType.Socialization)
        {
        }
    }
}