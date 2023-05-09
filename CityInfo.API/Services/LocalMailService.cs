namespace CityInfo.API.Services
{
    public class LocalMailService : IMailService
    {
        private readonly string senttomail = String.Empty;
        private readonly string sentfrommail = String.Empty;

        public LocalMailService(IConfiguration config)
        {
            sentfrommail = config["mailservices:frommail"];
            senttomail = config["mailservices:tomail"];
        }
        public void send(string message, string description)
        {
            Console.WriteLine($"Sent from {sentfrommail}" + $" to {senttomail}");
            Console.WriteLine(message);
            Console.WriteLine(description);
        }
    }
}
