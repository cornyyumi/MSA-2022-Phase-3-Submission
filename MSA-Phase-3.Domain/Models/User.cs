using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MSA_Phase_3.Domain.Models
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
    }
}
