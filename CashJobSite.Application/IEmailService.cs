
namespace CashJobSite.Application
{
    public interface IEmailService
    {
        void SendEmail(string toEmailAddress, string emailSubject, string emailBody);
    }
}
