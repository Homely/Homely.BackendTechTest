using System.Threading.Tasks;

namespace ThirdPartyLib
{
    public class SomeServiceYouCantChange
    {
        public async Task<string> ReturnsTheStringYouWantAsync()
        {
            await Task.Delay(1000);
            return "you've fixed me!";
        }
    }
}
