using Nancy;
using RegistrationService.Abstract.Interfaces;
using RegistrationService.Code.Models;

namespace RegistrationService.Code.Modules;

public class RegistrationModule : NancyModule
{
    public RegistrationModule(IUserStore userStore, IEventSender eventSender) : base("/auth")
    {
        Get("/", _ => View["Index.html"]);
        Post("/user", parameters =>
        {
            var user = (User)parameters.user;
            userStore.Save(user);
            eventSender.Raise();
            return View["StartPage.html"];
        });
    }
}
