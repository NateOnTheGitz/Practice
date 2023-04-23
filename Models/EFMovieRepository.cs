using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Models
{
    public class EFMovieRepository : IMovieRepository
    {
        private MovieContext _context { get; set; }

        public EFMovieRepository(MovieContext temp)
        {
            _context = temp;
        }
        public IQueryable<MovieInfo> MovieInfos => _context.MovieInfos;

        public IQueryable<Category> Categories => _context.Categories;

        public IEnumerable<MovieInfo> GetMovieInfos()
        {
            var movies = _context.MovieInfos
                .Include(x => x.Category)
                .ToList();

            return movies;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public MovieInfo GetMovieByID(int id)
        {
            return _context.MovieInfos.Single(x => x.MovieID == id);
        }

        public Category GetCategoryByID(int id)
        {
            return _context.Categories.Single(x => x.CategoryID == id);
        }

        public void AddMovie(MovieInfo MI)
        {
            _context.MovieInfos.Add(MI);
        }

        public void DeleteMovie(MovieInfo MI)
        {
            //var record = _context.MovieInfos.Single(x => x.MovieID == id);
            _context.Remove(MI);
        }

        public void EditMovie(MovieInfo MI)
        {
            _context.Update(MI);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
