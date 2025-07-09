namespace Bookify.Infrastructre.Email;
internal sealed class EmailService : IEmailService
{
    public Task SendAsync(Domain.Users.Email recepient, string subject, string body)
    {
        throw new NotImplementedException();
    }
}
