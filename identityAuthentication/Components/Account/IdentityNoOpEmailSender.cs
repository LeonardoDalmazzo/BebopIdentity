using identityAuthentication.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace identityAuthentication.Components.Account
{
    // Remove the "else if (EmailSender is IdentityNoOpEmailSender)" block from RegisterConfirmation.razor after updating with a real implementation.
    internal sealed class IdentityNoOpEmailSender : IEmailSender<ApplicationUser>
    {
        private readonly IEmailSender emailSender = new NoOpEmailSender();

        public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink) =>
            emailSender.SendEmailAsync(email, "Confirme seu email", $"Por favor, confirme sua conta <a href='{confirmationLink}'>clicando aqui</a>.");

        public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink) =>
            emailSender.SendEmailAsync(email, "Redefina sua senha", $"Por favor, redefina sua senha <a href='{resetLink}'>clicando aqui</a>.");

        public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode) =>
            emailSender.SendEmailAsync(email, "Redefina sua senha", $"Por favor, redefina sua senha usando o seguinte código: {resetCode}");
    }
}
