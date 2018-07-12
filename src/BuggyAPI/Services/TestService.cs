using System.Threading.Tasks;

namespace BuggyAPI.Services
{
    public class TestService
    {
        public async Task<string> GetDataAsync()
        {
            await Task.Delay(1000);
            return "you've fixed me!";
        }
    }
}