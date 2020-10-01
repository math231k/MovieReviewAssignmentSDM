using System;
using System.Collections.Generic;
using System.Text;

namespace MovieReviewAssignment.Core.Entities
{
    public class MovieRating
    {
        public int Reviewer { get; set; }
        public int Movie { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }

        public MovieRating(int r, int m, int g, DateTime d)
        {
            Reviewer = r;
            Movie = m;
            Grade = g;
            Date = d;
        }

    }
}
