using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Orchestrator;
public class GetGamesList(ILogger<GetGamesList> logger)
{

    // Modèle simple pour décrire un jeu
    public record GameInfo(string Id, string Name);

    [Function("GetGamesList")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "games")] HttpRequestData req)
    {
        logger.LogInformation("C# HTTP trigger function processed a request for GetGamesList.");

        // Pour l'instant, la liste est codée en dur.
        // Plus tard, elle pourrait venir d'une base de données ou d'une configuration.
        var games = new List<GameInfo>
        {
            new("bataille", "Bataille"),
        };

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(games);
        return response;
    }
}
