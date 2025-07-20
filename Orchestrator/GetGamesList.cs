using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Orchestrator;
public class GetGamesList(ILogger<GetGamesList> logger)
{

    // Mod�le simple pour d�crire un jeu
    public record GameInfo(string Id, string Name);

    [Function("GetGamesList")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "games")] HttpRequestData req)
    {
        logger.LogInformation("C# HTTP trigger function processed a request for GetGamesList.");

        // Pour l'instant, la liste est cod�e en dur.
        // Plus tard, elle pourrait venir d'une base de donn�es ou d'une configuration.
        var games = new List<GameInfo>
        {
            new("bataille", "Bataille"),
        };

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(games);
        return response;
    }
}
