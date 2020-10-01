using System;
using Xunit;
using Moq;
using FluentAssertions;
using System.Collections.Generic;
using MovieReviewAssignment.Core.Entities;
using MovieReviewAssignment.Core;
using MovieReviewAssignment.Core.Implementation;

namespace XUnitTestProject
{
    public class MovieReviewServiceTest
    {

        private List<MovieRating> ratings = null;
        private readonly Mock<IReviewRepository> repoMock;

        public MovieReviewServiceTest()
        {
            repoMock = new Mock<IReviewRepository>();
            repoMock.Setup(repo => repo.GetAllMovieRatings()).Returns(() => ratings);
        }


        //Opgave 1
        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        public void NumberOfReviewsFromReviewer(int review, int expected)
        {
            //ARRANGE
            ratings = new List<MovieRating>()
            {
                new MovieRating(1, 10, 3, DateTime.Now),
                new MovieRating(1, 11, 2, DateTime.Now),
                new MovieRating(2, 10, 4, DateTime.Now),
                new MovieRating(3, 10, 1, DateTime.Now)
            };
            ReviewService rs = new ReviewService(repoMock.Object);


            //ACT
            int result = rs.GetNumberOfReviewsFromReviewer(review);


            //ASSERT
            Assert.Equal(expected, result);
            repoMock.Verify(repo => repo.GetAllMovieRatings(), Times.Once);
        }

        //Opgave 2
        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 4)]
        [InlineData(3, 5)]
        public void AverageRateFromReviewer(int reviewer, int expected)
        {
            //ARRANGE
            ratings = new List<MovieRating>()
            {
                new MovieRating(1, 1, 3, DateTime.Now),
                new MovieRating(2, 1, 4, DateTime.Now),
                new MovieRating(3, 1, 5, DateTime.Now)
            };
            ReviewService rs = new ReviewService(repoMock.Object);


            //ACT
            double result = rs.GetAverageRateFromReviewer(reviewer);


            //ASSERT
            Assert.Equal(expected, result);
            repoMock.Verify(repo => repo.GetAllMovieRatings(), Times.Once);
        }


        //Opgave 3
        [Theory]
        [InlineData(1, 5, 1)]
        [InlineData(1, 4, 1)]
        [InlineData(2, 3, 1)]

        public void NumberOfRatesByReviewer(int reviewer, int grade, int expected)
        {
            //ARRANGE
            ratings = new List<MovieRating>()
            {
                new MovieRating(1, 1, 5, DateTime.Now),
                new MovieRating(1, 2, 4, DateTime.Now),
                new MovieRating(2, 1, 3, DateTime.Now)
            };
            ReviewService rs = new ReviewService(repoMock.Object);

            //ACT
            int result = rs.GetNumberOfRatesByReviewer(reviewer, grade);

            //ASSERT
            Assert.Equal(expected, result);
            repoMock.Verify(repo => repo.GetAllMovieRatings(), Times.Once);

        }

        //Opgave 7
        [Fact]
        public void GetMoviesWithHighestNumberOfTopRates()
        {
            //ARRANGE
            ratings = new List<MovieRating>()
            {
                new MovieRating(1, 1, 5, DateTime.Now),
                new MovieRating(1, 2, 5, DateTime.Now),

                new MovieRating(2, 1, 4, DateTime.Now),
                new MovieRating(2, 2, 5, DateTime.Now),

                new MovieRating(2, 3, 5, DateTime.Now),
                new MovieRating(3, 3, 5, DateTime.Now),
            };
            ReviewService rs = new ReviewService(repoMock.Object);

            List<int> expected = new List<int>() { 2, 3 };

            //ACT
            var result = rs.GetMoviesWithHighestNumberOfTopRates();

            //ASSERT
            Assert.Equal(expected, result);
            repoMock.Verify(repo => repo.GetAllMovieRatings(), Times.Once);

        }
        

    }
}
