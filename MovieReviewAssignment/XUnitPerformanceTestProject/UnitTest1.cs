using Moq;
using MovieReviewAssignment.Core;
using MovieReviewAssignment.Core.Entities;
using MovieReviewAssignment.Core.Implementation;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitPerformanceTestProject
{
    public class UnitTest1
    {
        private List<MovieRating> ratings = null;
        private readonly Mock<IReviewRepository> repoMock;

        public UnitTest1()
        {
            repoMock = new Mock<IReviewRepository>();
            repoMock.Setup(repo => repo.Ratings).Returns(() => ratings.ToArray());
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
            repoMock.Verify(repo => repo.Ratings, Times.Once);
        }

        //Opgave 2
        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 4)]
        [InlineData(3, 5)]
        public void AverageRateFromReviewer(int reviewer, double expected)
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
            repoMock.Verify(repo => repo.Ratings, Times.Once);
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
            repoMock.Verify(repo => repo.Ratings, Times.Once);

        }

        //Opgave 4
        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 2)]
        [InlineData(3, 1)]
        public void NumberOfReviewsOnMovie(int movie, int expected)
        {
            //ARRANGE
            ratings = new List<MovieRating>()
            {
                new MovieRating(1, 1, 3, DateTime.Now),
                new MovieRating(2, 1, 2, DateTime.Now),
                new MovieRating(3, 1, 3, DateTime.Now),
                new MovieRating(1, 2, 2, DateTime.Now),
                new MovieRating(2, 2, 3, DateTime.Now),
                new MovieRating(3, 3, 5, DateTime.Now)
            };
            ReviewService rs = new ReviewService(repoMock.Object);

            //ACT
            int result = rs.GetNumberOfReviews(movie);

            //ASSERT
            Assert.Equal(expected, result);
            repoMock.Verify(repo => repo.Ratings, Times.Once);
        }

        //Opgave 5
        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 4)]
        public void AverageRatingOnMovie(int movie, double average)
        {
            //ARRANGE
            ratings = new List<MovieRating>()
            {
                new MovieRating(1, 1, 2, DateTime.Now),
                new MovieRating(2, 1, 4, DateTime.Now),
                new MovieRating(2, 2, 5, DateTime.Now),
                new MovieRating(3, 2, 3, DateTime.Now)
            };
            ReviewService rs = new ReviewService(repoMock.Object);

            //ACT
            double result = rs.GetAverageRateOfMovie(movie);

            //ASSERT
            Assert.Equal(average, result);
            repoMock.Verify(repo => repo.Ratings, Times.Once);
        }

        //Opgave 6
        [Theory]
        [InlineData(1, 2, 4)]
        [InlineData(1, 5, 2)]
        [InlineData(2, 4, 3)]
        [InlineData(3, 1, 7)]
        public void TestGetNumbersRates(int movie, int rate, int expected)
        {
            //Arrange
            ReviewService rs = new ReviewService(repoMock.Object);
            ratings = new List<MovieRating>
            {
                new MovieRating(1, 1, 2, DateTime.Now),
                new MovieRating(2, 1, 2, DateTime.Now),
                new MovieRating(3, 1, 2, DateTime.Now),
                new MovieRating(4, 1, 2, DateTime.Now),
                new MovieRating(5, 1, 5, DateTime.Now),
                new MovieRating(6, 1, 5, DateTime.Now),
                new MovieRating(7, 2, 4, DateTime.Now),
                new MovieRating(8, 2, 4, DateTime.Now),
                new MovieRating(9, 2, 4, DateTime.Now),
                new MovieRating(10, 3, 1, DateTime.Now),
                new MovieRating(11, 3, 1, DateTime.Now),
                new MovieRating(12, 3, 1, DateTime.Now),
                new MovieRating(13, 3, 1, DateTime.Now),
                new MovieRating(14, 3, 1, DateTime.Now),
                new MovieRating(15, 3, 1, DateTime.Now),
                new MovieRating(16, 3, 1, DateTime.Now)

            };

            //ACT
            var result = rs.GetNumberOfRates(movie, rate);

            //ASSERT

            Assert.Equal(result, expected);
            repoMock.Verify(repo => repo.Ratings, Times.Once);

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
            repoMock.Verify(repo => repo.Ratings, Times.Once);

        }

        //Opgave 8
        [Fact]
        public void TestGetMostProductiveReviewers()
        {
            //ARRANGE
            ReviewService rs = new ReviewService(repoMock.Object);
            List<int> expected = new List<int>() { 1, 3 };

            ratings = new List<MovieRating>()
            {
                new MovieRating(1, 1, 5, DateTime.Now),
                new MovieRating(1, 2, 5, DateTime.Now),

                new MovieRating(1, 1, 4, DateTime.Now),
                new MovieRating(2, 2, 5, DateTime.Now),

                new MovieRating(2, 3, 5, DateTime.Now),
                new MovieRating(3, 3, 5, DateTime.Now),

                new MovieRating(3, 3, 5, DateTime.Now),
                new MovieRating(3, 3, 5, DateTime.Now),
            };

            //Act
            var result = rs.GetMostProductiveReviewers();

            //ASSERT
            Assert.Equal(expected, result);
            repoMock.Verify(repo => repo.Ratings, Times.Once);
        }

        //Opgave 9
        [Fact]
        public void GetTopRatedMoviesPagedTest()
        {
            //ARRANGE
            ReviewService rs = new ReviewService(repoMock.Object);
            ratings = new List<MovieRating>()
            {
                new MovieRating(1, 8, 5, DateTime.Now),
                new MovieRating(2, 4, 1, DateTime.Now),

                new MovieRating(2, 7, 5, DateTime.Now),
                new MovieRating(1, 6, 2, DateTime.Now),

                new MovieRating(7, 2, 3, DateTime.Now),
                new MovieRating(1, 1, 2, DateTime.Now),

                new MovieRating(6, 35, 5, DateTime.Now),
                new MovieRating(8, 34, 2, DateTime.Now),

                new MovieRating(2, 5, 1, DateTime.Now),
                new MovieRating(4, 4, 4, DateTime.Now),

                new MovieRating(3, 2, 1, DateTime.Now),
                new MovieRating(6, 8, 2, DateTime.Now),

                new MovieRating(2, 2, 4, DateTime.Now),
                new MovieRating(1, 1, 5, DateTime.Now),

                new MovieRating(6, 2, 1, DateTime.Now),
                new MovieRating(3, 6, 2, DateTime.Now)
            };

            var expected = new List<int>()
            {
                7, 35, 1, 8,
            };

            //ACT
            var result = rs.GetTopRatedMovies(4);
            //ASSERT
            Assert.Equal(expected, result);
            repoMock.Verify(repo => repo.Ratings, Times.Once);
        }

        //Opgave 10
        [Fact]
        public void GetReviewedMoviesByRevivierverInOrderDescendingTest()
        {
            //ARRANGE
            ReviewService rs = new ReviewService(repoMock.Object);
            ratings = new List<MovieRating>()
            {
                new MovieRating(1, 8, 5, DateTime.Now),
                new MovieRating(1, 4, 1, DateTime.MinValue),
                new MovieRating(1, 7, 3, DateTime.MaxValue),
                new MovieRating(2, 2, 1, DateTime.Now),
                new MovieRating(3, 6, 2, DateTime.Now)
            };

            var expected = new List<int>()
            {
                8, 7, 4,
            };

            //ACT
            var result = rs.GetTopMoviesByReviewer(1);

            //ASSERT
            Assert.Equal(expected, result);
            repoMock.Verify(repo => repo.Ratings, Times.Once);
        }

        //Opgave 11
        [Fact]
        public void GetReviewersByMovieTest()
        {
            //ARRANGE
            ReviewService rs = new ReviewService(repoMock.Object);
            ratings = new List<MovieRating>()
            {
                new MovieRating(1, 2, 5, DateTime.Now),
                new MovieRating(2, 2, 3, DateTime.MinValue),
                new MovieRating(4, 2, 3, DateTime.MaxValue),
                new MovieRating(3, 2, 1, DateTime.Now),
                new MovieRating(3, 3, 2, DateTime.Now),
                new MovieRating(1, 4, 5, DateTime.Now),
                new MovieRating(2, 4, 3, DateTime.MinValue),
                new MovieRating(4, 4, 3, DateTime.MaxValue),
                new MovieRating(3, 4, 1, DateTime.Now),
                new MovieRating(3, 4, 2, DateTime.Now)
            };

            var expected = new List<int>()
            {
                1, 4, 2, 3,
            };

            //ACT
            var result = rs.GetReviewersByMovie(2);

            //ASSERT
            Assert.Equal(expected, result);
            repoMock.Verify(repo => repo.Ratings, Times.Once);
        }
    }
}
