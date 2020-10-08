using MovieReviewAssignment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReviewAssignment.Core
{
    public interface IReviewRepository
    {
        MovieRating[] Ratings { get; }
    }
}
