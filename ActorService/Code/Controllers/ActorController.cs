using ActorService.Abstract.Interfaces;
using ActorService.Code.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActorService.Code.Controllers;
public class ActorController : Controller
{
    IActorStore _actorStore;
    IEventSender _eventSender;

    public ActorController(IActorStore actorStore, IEventSender eventSender)
    {
        _actorStore = actorStore;
        _eventSender = eventSender;
    }

    public JsonResult GetActorList(Int32 filmId)
    {
        var response = _actorStore.Get(filmId);
        return Json(response);
    }
    [HttpPost]
    public Task<IActionResult> AddActor(Actor actor, Int32 userId)
    {
        _actorStore.Add(actor);
        _eventSender.Raise("actor_eventType:addition",userId,$"just added {actor.Id}");
        return null;
    }
}
