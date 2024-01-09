using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoCatalog.Services
{
    public interface IVideoApiService
    {
        Task<string> GetJsonVideoResponseAsync(string apiUrl);

        Task<bool> IsNetWorkConnected(string url);
    }
}
