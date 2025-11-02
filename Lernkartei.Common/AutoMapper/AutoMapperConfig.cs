using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Lernkartei.Common.AutoMapper;

public static class AutoMapperConfig
{
    private static readonly Lazy<IMapper> _mapper = new(() =>
    {
        var expression = new MapperConfigurationExpression();

        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        var config = new MapperConfiguration(expression, loggerFactory);

        config.AssertConfigurationIsValid();

        return config.CreateMapper();
    });

    public static IMapper Mapper => _mapper.Value;
}