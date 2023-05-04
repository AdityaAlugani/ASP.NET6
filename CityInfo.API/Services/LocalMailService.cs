namespace CityInfo.API.Services
{
    public class LocalMailService
    {
        private string senttomail="abc@gmail.com";
        private string sentfrommail="demo@gmail.com";
        public void send(string message,string description)
        {
            Console.WriteLine($"Sent from {senttomail}"+$" to {sentfrommail}");
            Console.WriteLine(message);
            Console.WriteLine(description);
        }
    }
}
