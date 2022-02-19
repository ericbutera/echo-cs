// Update on https://carlos.mendible.com/2018/04/04/using-docker-multi-stage-builds-to-build-an-asp-net-core-echo-server/
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

public class Echo
{
    public static void Main()
    {
        new WebHostBuilder()
            .UseKestrel(options => {
                options.Limits.MaxConcurrentConnections = 1000;
            })
            .Configure(app =>
                app.Run(async context => {
                    var req = context.Request;
                    var res = context.Response;

                    res.ContentType = "application/json";

                    var headers = req.Headers.Select(h => new
                    {
                        h.Key,
                        h.Value
                    });

                    using (var reader = new StreamReader(req.Body))
                    {
                        var data = new
                        {
                            Headers = headers,
                            Body = reader.ReadToEndAsync().Result
                        };

                        var json = JsonSerializer.Serialize(data);
                        await context.Response.WriteAsync(json);
                    }
                })
            )
            .Build()
            .Run();
    }
}