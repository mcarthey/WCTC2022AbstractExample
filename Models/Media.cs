namespace AbstractExample.Models
{
    public abstract class Media
    {
        public int Id { get; set; } // common properties
        public string Title { get; set; } //common properties

        public abstract void Display();
        public abstract void Read();
    }
}
