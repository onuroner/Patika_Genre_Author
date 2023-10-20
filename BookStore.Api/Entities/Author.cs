﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Api.Entities
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        public List<Book> Books { get; set; }
    }
}
