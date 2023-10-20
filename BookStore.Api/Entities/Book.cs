using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Api.Entities
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Author Author { get; set; }
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }

    }
}