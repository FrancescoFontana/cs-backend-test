using QadraBackendTest.Clients.Implementations;
using QadraBackendTest.Clients.Interfaces;

namespace QadraBackendTest.Clients.Factories;

public static class DataSourceFactory
{
    public const string DataSourceNameEnvironmentKey = "DataSourceNames";

    private static readonly Dictionary<string, IDataSourceClient> _cache = new();

    static DataSourceFactory()
    {
        var namesString = Environment.GetEnvironmentVariable(DataSourceNameEnvironmentKey);

        if (string.IsNullOrWhiteSpace(namesString))
            throw new InvalidOperationException("DataSource names missing.");

        var mapping = ParseEnvironmentMapping(namesString);

        PopulateClients(mapping);
    }

    private static void PopulateClients(IDictionary<string, Type> mapping)
    {
        if (!mapping.Values.All(type => type.IsAssignableTo(typeof(IDataSourceClient))))
            throw new InvalidOperationException("Wrong mapping");

        foreach (var map in mapping)
        {
            var client = (Activator.CreateInstance(map.Value) as IDataSourceClient)!;

            _cache.Add(map.Key, client);
        }
    }

    private static IDictionary<string, Type> ParseEnvironmentMapping(string environmentMapping)
    {
        var strings = environmentMapping.Split(';');

        var mappings = new Dictionary<string, Type>();

        foreach (var s in strings)
        {
            var pair = s.Split('=');

            var type = Type.GetType(pair[1]) ?? throw new InvalidOperationException($"{pair[1]} is not a type.");

            mappings.Add(pair[0], type);
        }

        return mappings;
    }

    public static IDataSourceClient GetClientByName(string name)
    {
        if (_cache.TryGetValue(name, out var client))
        {
            return client;
        }
        else
        {
            switch (name)
            {
                case "Apple":
                    {
                        client = new EodClient();
                        break;
                    }
                case "Microsoft":
                    {
                        client = new MsClient();
                        break;
                    }
                default:
                    throw new ArgumentException("Wrong name.");
            }

            _cache.Add(name, client);

            return client;
        }
    }
}