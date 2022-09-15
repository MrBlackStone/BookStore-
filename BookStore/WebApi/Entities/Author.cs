using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int authorId { get; set; }
        public string authorName { get; set; }
        public string  authorSurname { get; set; }
        public DateTime birthDate { get; set; }
    }
}