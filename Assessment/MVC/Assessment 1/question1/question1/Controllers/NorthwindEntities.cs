namespace question1.Controllers
{
    internal class NorthwindEntities
    {
        public NorthwindEntities()
        {
        }

        public object Customers { get; internal set; }
        public object Orders { get; internal set; }
    }
}