using System;
using System.Collections.Generic;
using System.Linq;
using MyProjectOData.Models.Test;

namespace MyProjectOData.Retrievers.Test
{
    public class TestDataService
    {
        public IQueryable<Movie> Movies
        {
            get { return MMovies.AsQueryable(); }
        }

        private static readonly List<Movie> MMovies = new []
        {
            new Movie { Id = 1, Rating = StarRating.FiveStar, ReleaseDate = new DateTime(2015, 10, 25), Title = "StarWars - The Force Awakens", Director = new Person { FirstName="J.J.", LastName="Abrams" } },
            new Movie { Id = 2, Rating = StarRating.FourStar, ReleaseDate = new DateTime(2015, 5, 15), Title = "Mad Max - The Fury Road", Director = new Person { FirstName ="George", LastName="Miller" } }
        }.ToList();

        public IQueryable<Product> Products
        {
            get { return PProducts.AsQueryable(); }
        }

        private static readonly List<Product> PProducts = new[]
        {
            new Product { Id = 1, Name  = "Apple"},
            new Product { Id = 2, Name="Google" }
        }.ToList();
    }
}