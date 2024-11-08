namespace WebApplication1.Services
{
    public class RandomStringService1: IRandomStringHolder
    {
        public string RandomString { get; set; }
        public RandomStringService1()
        {
            RandomString = Guid.NewGuid().ToString();
        }
    }
}
