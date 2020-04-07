using SampleApi.Models;

namespace SampleApi.DAL
{
    public interface IBreweryDAO
    {
        int AddBrewery(Brewery brewery);
        Brewery GetBreweryById(int id);
    }
}