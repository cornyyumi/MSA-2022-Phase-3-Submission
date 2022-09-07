using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSA_Phase_3.Domain.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string title { get; set; }
        public string? Isbn_13 { get; set; }
        public string? fileImageURL { get; set; }
        public string? description { get; set; }
    }
}
