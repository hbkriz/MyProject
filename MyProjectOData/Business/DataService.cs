using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyProjectOData.Models;

namespace MyProjectOData.Business
{
    public class DataService
    {
        public IQueryable<Movie> Movies
        {
            get { return m_movies.AsQueryable(); }
        }
        public Movie Find(int id)
        {
            return Movies.FirstOrDefault(m => m.Id == id);
        }
        
        private static List<Movie> m_movies = new Movie[]
        {
            new Movie { Id = 1, Rating = StarRating.FiveStar, ReleaseDate = new DateTime(2015, 10, 25), Title = "StarWars - The Force Awakens", Director = new Person { FirstName="J.J.", LastName="Abrams" } },
            new Movie { Id = 2, Rating = StarRating.FourStar, ReleaseDate = new DateTime(2015, 5, 15), Title = "Mad Max - The Fury Road", Director = new Person { FirstName ="George", LastName="Miller" } }
        }.ToList();
    }
}