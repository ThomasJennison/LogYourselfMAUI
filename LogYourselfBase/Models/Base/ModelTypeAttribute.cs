namespace LogYourself.Models.Base
{
    [AttributeUsage(AttributeTargets.All)]
    public class ModelTypeAttribute : Attribute
    {
        public ModelType ModelType { get; set; }

        public ModelTypeAttribute(ModelType type)
        {
            ModelType = type;
        }
    }
}