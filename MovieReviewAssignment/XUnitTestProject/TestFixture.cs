﻿using MovieRatingsJSONRepository;
using MovieReviewAssignment.Core;
using System;
using System.Linq;

namespace XUnitTestProject___PerformanceTest
{
    public class TestFixture : IDisposable
    {
        const string JSÒN_FILE_NAME = @"C:\Users\Rizvan\Documents\GitHub\MovieReviewAssignmentSDM\MovieReviewAssignment\MovieReviewAssignment.Infrastructure\ratings.json";

        public IReviewRepository Repository {get; private set;}
        public int ReviewerMostReviews { get; private set; }
        public int MovieMostReviews { get; private set; }
        public int NumberOfRates { get; private set; }
        public int MovieNumberOfReviews { get; private set; }
        public TestFixture()
        {
            Repository = new ReviewRepository(JSÒN_FILE_NAME);

             ReviewerMostReviews = Repository.Ratings
                .GroupBy(r => r.Reviewer)
                .Select(grp => new
                {
                    reviewer = grp.Key,
                    reviews = grp.Count()
                })
                .OrderByDescending(grp => grp.reviews)
                .Select(grp => grp.reviewer)
                .FirstOrDefault();

            MovieMostReviews = Repository.Ratings
                .GroupBy(r => r.Movie)
                .Select(grp => new
                {
                    movie = grp.Key,
                    reviews = grp.Count()
                })
                .OrderByDescending(grp => grp.reviews)
                .Select(grp => grp.movie)
                .FirstOrDefault();


        }

        public void Dispose()
        {
            // Nothing to do here.           
        }
    }
}
