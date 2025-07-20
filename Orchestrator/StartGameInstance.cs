using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Orchestrator;

public class StartGameInstance(ILogger<StartGameInstance> logger)
{
    public record StartGameResponse(string WebSocketUrl);

    [Function("StartGameInstance")]
    public HttpResponseData Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "games/{gameId}/start")] HttpRequestData req,
        string gameId)
    {
        logger.LogInformation("Request to start game: {gameId}", gameId);

        // TODO : Ajouter la vraie logique pour démarrer un conteneur ACI
        // Pour l'instant, on renvoie l'URL du serveur de bataille déjà déployé.
        var mockUrl = $"ws://war-server-watashiku.francecentral.azurecontainer.io";

        var responsePayload = new StartGameResponse(mockUrl);

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.WriteAsJsonAsync(responsePayload);
        return response;
    }
}
