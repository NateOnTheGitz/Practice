using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Models
{
    public interface IMovieRepository
    {
        IQueryable<MovieInfo> MovieInfos { get; }
        IQueryable<Category> Categories { get; }

        IEnumerable<MovieInfo> GetMovieInfos();
        IEnumerable<Category> GetCategories();
        MovieInfo GetMovieByID(int id);
        Category GetCategoryByID(int id);
        void AddMovie(MovieInfo MI);
        void DeleteMovie(MovieInfo MI);
        void EditMovie(MovieInfo MI);
        void Save();
    
    }
}
