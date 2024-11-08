namespace WebApplication1.Services
{
    public class RandomStringService2 : IRandomStringHolder
    {
        public RandomStringService2()
        {
            RandomString = new Random().NextInt64().ToString();
        }
        public string RandomString { get; set; }
    }
}
