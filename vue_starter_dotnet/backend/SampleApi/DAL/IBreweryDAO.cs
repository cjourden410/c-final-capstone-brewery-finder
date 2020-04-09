using System.Collections.Generic;
using SampleApi.Models;

namespace SampleApi.DAL
{
    public interface IBreweryDAO
    {
        int AddBrewery(Brewery brewery);
        Brewery GetBreweryById(int id);
        IList<Brewery> GetBreweries();
        void UpdateBreweryInfo(Brewery brewery);
        IList<Beer> GetBeersByBrewery(int breweryID);
        Beer GetBeerById(int id);
        int AddBeer(Beer beer);
    }
}