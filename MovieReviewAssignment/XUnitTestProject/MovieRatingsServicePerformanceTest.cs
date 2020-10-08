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


        public MovieRatingsServiceLinqPerformanceTest(TestFixture data)
        {
            repository = data.Repository;
            reviewerMostReviews = data.ReviewerMostReviews;
            movieMostReviews = data.MovieMostReviews;
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
                int result = mrs.GetNumberOfReviewsFromReviewer(reviewerMostReviews);
            });

            Assert.True(seconds <= 4);
        }
    }
}
