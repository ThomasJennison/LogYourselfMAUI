namespace LogYourself.Models.Base
{
    public abstract class LogModelBase
    {
        /// <summary>
        /// The time the model was registered by the user
        /// </summary>
        public DateTime RegisteredTime { get; set; }

        //TODO: Fix pkey attr with new sqlite package

        /// <summary>
        /// SQL key
        /// </summary>
        //[PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        /// <summary>
        /// Type of log
        /// </summary>
        public ModelType LogType { get; }

        protected LogModelBase(ModelType type)
        {
            LogType = type;
        }
    }
}