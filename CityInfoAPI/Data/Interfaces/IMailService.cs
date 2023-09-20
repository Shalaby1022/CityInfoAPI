namespace CityInfoAPI.Data.Interfaces
{
    public interface IMailService
    {
        void Send(string subject, string message);

    }
}
