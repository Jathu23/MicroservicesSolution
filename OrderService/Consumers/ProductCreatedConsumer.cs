using Common.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

public class ProductCreatedConsumer : IConsumer<IProductCreated>
{
    private readonly ILogger<ProductCreatedConsumer> _logger;

    public ProductCreatedConsumer(ILogger<ProductCreatedConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<IProductCreated> context)
    {
        var product = context.Message;
        _logger.LogInformation($"📩 Received Product Event: ID = {product.Id}, Name = {product.Name}");

        await Task.Delay(1000);
        _logger.LogInformation("✅ Order Created for Product: " + product.Name);
    }
}
