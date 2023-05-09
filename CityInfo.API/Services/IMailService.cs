namespace CityInfo.API.Services
{
    public interface IMailService
    {
        void send(string message, string description);
    }
}