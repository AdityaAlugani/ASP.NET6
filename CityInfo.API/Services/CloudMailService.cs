namespace CityInfo.API.Services
{
    public class CloudMailService : IMailService
    {
        private readonly string senttomail = String.Empty;
        private readonly string sentfrommail = String.Empty;

        public CloudMailService(IConfiguration config)
        {
            sentfrommail = config["mailservices:frommail"];
            senttomail= config["mailservices:tomail"];
        }
        public void send(string message, string description)
        {
            Console.WriteLine($"Sent from {senttomail}" + $" to {sentfrommail} "+"Cloud Mail Service");
            Console.WriteLine(message);
            Console.WriteLine(description);
        }
    }
}
