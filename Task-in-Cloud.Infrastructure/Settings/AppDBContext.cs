using Supabase;
using Microsoft.Extensions.Options;
using Task_in_Cloud.Infrastructure.Model;

namespace Task_in_Cloud.Infrastructure.Settings
{
    public class AppDBContext
    {
        private static Client? _client;
        private static readonly  object _lock = new();

        private readonly SupabaseSettings _settings;

        public AppDBContext(IOptions<SupabaseSettings> options)
        {
            _settings = options.Value;
        }

        public async Task<Client> GetClientAsync()
        {
            if (_client == null)
            {
                lock (_lock)
                {
                    if (_client == null)
                    {
                        _client = new Client(_settings.Url, _settings.Key);
                    }
                }
                await _client.InitializeAsync();
            }

            return _client;
        }
    }
}
