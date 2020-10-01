using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MovieReviewAssignment.Core.Implementation
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepo;

        public ReviewService(IReviewRepository reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            throw new NotImplementedException();       
        }

        public double GetAverageRateOfMovie(int movie)
        {
            throw new NotImplementedException();
        }

        public List<int> GetMostProductiveReviewers()
        {
            throw new NotImplementedException();
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            var rating5 = _reviewRepo.GetAllMovieRatings()
                .Where(r => r.Grade == 5)
                .GroupBy(r => r.Movie)
                .Select(group => new
                {
                    Movie = group.Key,
                    Grade5 = group.Count()
                });

            int ratingWith5 = rating5.Max(grp => grp.Grade5);

            return rating5
                .Where(grp => grp.Grade5 == ratingWith5)
                .Select(grp => grp.Movie)
                .ToList();
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfReviews(int movie)
        {
            throw new NotImplementedException();
        }

        //Opgave 1
        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            return _reviewRepo.GetAllMovieRatings()
                .Where(r => r.Reviewer == reviewer)
                .Count();
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            throw new NotImplementedException();
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            throw new NotImplementedException();
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
