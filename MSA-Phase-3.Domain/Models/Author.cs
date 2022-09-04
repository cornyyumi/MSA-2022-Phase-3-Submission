using System.ComponentModel.DataAnnotations;

namespace MSA_Phase_3.Domain.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
