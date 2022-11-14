namespace Emr.API.Models
{
    public class OptionWithActive<T>
    {
        public T Id { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}