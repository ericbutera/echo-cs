using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

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

                    Write(res.Body, "TIME: " + DateTime.Now);
                    Write(res.Body, req.Method + " " + req.Path + "\n");

                    var headers = req.Headers.Select(h => h.Key + ": " + h.Value);
                    Write(res.Body, "HEADERS:\n"+ string.Join("\n", headers) +"\n");

                    Write(res.Body, "BODY:");
                    using (var reader = new StreamReader(req.Body))
                    {
                        var body = await reader.ReadToEndAsync();
                        Write(res.Body, body);
                        // await req.Body.CopyToAsync(res.Body);
                    }
                })
            )
            .Build()
            .Run();
    }

    private static async void Write(Stream body, string text)
    {
        Console.WriteLine(text);

        var bytes = Encoding.UTF8.GetBytes(text + "\n");
        await body.WriteAsync(bytes);
    }
}