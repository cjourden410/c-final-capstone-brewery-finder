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
        BeerReview GetReviewById(int id);
        int AddReview(BeerReview review);
        IList<BeerReview> GetReviewsByBeer(int beerID);
        IList<BeerReview> GetReviewsByBrewery(int breweryID);
        IList<BeerReview> GetReviews();
        void DeleteBeer(int beerID);
        Beer GetRatingByBeerById(int id);
    }
}