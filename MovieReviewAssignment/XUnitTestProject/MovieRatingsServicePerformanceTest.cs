using MovieReviewAssignment.Core;
using MovieReviewAssignment.Core.Implementation;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace XUnitTestProject___PerformanceTest
{
    public class MovieRatingsServiceLinqPerformanceTest : IClassFixture<TestFixture>
    {
        //const string JSÒN_FILE_NAME = @"C:\Users\bhp\source\repos\PP\2020E\Compulsory\ratings.json";

        private IReviewRepository repository;

        private int reviewerMostReviews;
        private int movieMostReviews;
        private int movieNumberOfReviews;
        private int numberOfRates;


        public MovieRatingsServiceLinqPerformanceTest(TestFixture data)
        {
            repository = data.Repository;
            reviewerMostReviews = data.ReviewerMostReviews;
            movieMostReviews = data.MovieMostReviews;
            numberOfRates = data.NumberOfRates;
            movieNumberOfReviews = data.MovieNumberOfReviews;
        }

        private double TimeInSeconds(Action ac)
        {
            Stopwatch sw = Stopwatch.StartNew();
            ac.Invoke();
            sw.Stop();
            return sw.ElapsedMilliseconds / 1000d;
        }

        [Fact]
        public void GetNumberOfReviewsFromReviewer()
        {
            IReviewService mrs = new ReviewService(repository);

            double seconds = TimeInSeconds(() =>
            {
                int result = mrs.GetNumberOfReviewsFromReviewer(1);
            });

            Assert.True(seconds <= 4);
        }

        [Fact]
        public void GetAverageRateFromReviewer()
        {
            IReviewService mrs = new ReviewService(repository);

            double seconds = TimeInSeconds(() =>
            {
                int result = (int)mrs.GetAverageRateFromReviewer(1);
            });

            Assert.True(seconds <= 4);
        }

        [Fact]
        public void GetNumberOfRatesByReviewer()
        {
            IReviewService mrs = new ReviewService(repository);

            double seconds = TimeInSeconds(() =>
            {
                int result = mrs.GetNumberOfRatesByReviewer(1, 1);
            });

            Assert.True(seconds <= 4);
        }

        [Fact]
        public void GetNumberOfReviews()
        {
            IReviewService mrs = new ReviewService(repository);

            double seconds = TimeInSeconds(() =>
            {
                int result = mrs.GetNumberOfReviews(1);
            });

            Assert.True(seconds <= 4);
        }

        [Fact]
        public void TopRatedMovies()
        {
            IReviewService mrs = new ReviewService(repository);

            double seconds = TimeInSeconds(() =>
            {
                List<int> result = mrs.GetTopRatedMovies(500000000);
            });
            
            Assert.True(seconds <= 4);
        }

    }
}
