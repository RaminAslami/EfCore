using System.Collections;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface;

public interface IReviewRepository
{
    ICollection<Review> GetReviews();
    Review GetReview(int reviewId);
    ICollection<Review> GetReviewsofAPokemon(int pokeId);
    bool ReviewExists(int pokeId);
    
    /*
     * 	public int Id { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public int Rating { get; set; }
		public Reviewer Reviewer { get; set; }
		public Pokemon Pokemon { get; set; }
     */
}