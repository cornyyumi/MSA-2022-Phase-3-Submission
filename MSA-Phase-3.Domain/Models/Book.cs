using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSA_Phase_3.Domain.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Isbn_13 { get; set; }

    }
}
