using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using Product.Domain.Interfaces;
using static Amazon.Lambda.SQSEvents.SQSEvent;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Product.Lambda;

public class Function
{
    private readonly IProductService _productService;

    public Function()
    {
        Startup.ConfigureServices();
        _productService = Startup.Services.GetRequiredService<IProductService>();
    }

    public async Task FunctionHandler(SQSEvent evnt, ILambdaContext context)
    {
        foreach(var message in evnt.Records)
        {
            await ProcessMessageAsync(message, context);
        }
    }

    private async Task ProcessMessageAsync(SQSMessage message, ILambdaContext context)
    {
        context.Logger.LogInformation($"Processed message {message.Body}");

        await _productService.AddProduct(message);

        await Task.CompletedTask;
    }
}