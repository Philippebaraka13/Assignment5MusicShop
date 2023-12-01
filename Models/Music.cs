using System.ComponentModel.DataAnnotations;

namespace Assignment5MusicShop.Models
{
    public class Music
    {
        public required int Id { get; set; }

        public required string Title { get; set; }

        public required string Performer { get; set; }
        public required string Genre { get; set; }
        public decimal Price { get; set; }
        public int Year {  get; set; }


    }
}
