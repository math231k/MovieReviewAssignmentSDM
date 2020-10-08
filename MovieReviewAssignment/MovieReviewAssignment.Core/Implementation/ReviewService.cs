using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics.CodeAnalysis;
using MovieReviewAssignment.Core.Entities;
using System.Security.Cryptography.X509Certificates;

namespace MovieReviewAssignment.Core.Implementation
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepo;

        public ReviewService(IReviewRepository reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        public int NumberOfMoviesWithGrade(int grade)
        {
            if (grade < 1 || grade > 5)
            {
                throw new ArgumentException("Grade must be 1 - 5");
            }

            HashSet<int> movies = new HashSet<int>();
            foreach (MovieRating rating in _reviewRepo.Ratings)
            {
                if (rating.Grade == grade)
                {
                    movies.Add(rating.Movie);
                }
            }
            return movies.Count;
        }

        //opg 1
        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            return _reviewRepo.Ratings
                .Where(r => r.Reviewer == reviewer)
                .Count();
        }

        //opg 2
        public double GetAverageRateFromReviewer(int reviewer)
        {

            var result = _reviewRepo.Ratings
                .Where(r => r.Reviewer == reviewer)
                .Select(x => x.Grade)
                .Average();

            return result;
            
        }

        //opg 3
        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            return _reviewRepo.Ratings
                .Where(r => r.Reviewer == reviewer)
                .Where(g => g.Grade == rate)
                .Count();
        }

        //opg 4
        public int GetNumberOfReviews(int movie)
        {
            return _reviewRepo.Ratings
                .Where(r => r.Movie == movie)
                .Select(x => x.Grade)
                .Count();
        }

        //opg 5
        public double GetAverageRateOfMovie(int movie)
        {
            return _reviewRepo.Ratings
                .Where(r => r.Movie == movie)
                .Select(x => x.Grade)
                .Average();
        }


        //opg 6
        public int GetNumberOfRates(int movie, int rate)
        {
            return _reviewRepo.Ratings
                .Where(m => m.Movie == movie)
                .Where(g => g.Grade == rate)
                .Count();
        }

        //opg 7
        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            var rating5 = _reviewRepo.Ratings
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

        //opg 8
        public List<int> GetMostProductiveReviewers()
        {
            var productivity = _reviewRepo.Ratings
                .GroupBy(r => r.Reviewer)
                .Select(group => new
                {
                    Reviewer = group.Key,
                    Reviews = group.Count()
                }
                );

            var mostProductiveReviewer = productivity.Max(grp => grp.Reviews);

            return productivity
                .Where(grp => grp.Reviews == mostProductiveReviewer).
                Select(grp => grp.Reviewer).
                ToList();
        }


        //opg 9
        public List<int> GetTopRatedMovies(int amount)
        {

            var ratings = _reviewRepo.Ratings.
                GroupBy(m => m.Movie).
                Select(group => new 
                { 
                    Movie = group.Key,
                    Rating = group.Average(x => x.Grade)
                   
                });

            var results = ratings.
                OrderByDescending(grp => grp.Rating).
                ThenBy(grp => grp.Movie).
                Select(grp => grp.Movie).
                Take(amount).
                ToList();

            return results;

        }

        //opg 10
        public List<int> GetTopMoviesByReviewer(int reviewer)
        {

            return _reviewRepo.Ratings.
                Where(grp => grp.Reviewer == reviewer).
                OrderByDescending(grp => grp.Grade).
                ThenBy(grp => grp.Date).
                Select(grp => grp.Movie).
                ToList();
        }

        //opg 11
        public List<int> GetReviewersByMovie(int movie)
        {
            return _reviewRepo.Ratings.
                Where(grp => grp.Movie == movie).
                OrderByDescending(grp => grp.Grade).
                ThenByDescending(grp => grp.Date).
                Select(grp => grp.Reviewer).
                ToList();
        }


    }
}
