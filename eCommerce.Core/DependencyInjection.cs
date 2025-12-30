using Microsoft.Extensions.DependencyInjection;


namespace eCommerce.Core;
public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection service)
    {
        return service;
    }
}