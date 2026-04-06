using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Books.Dtos
{
    public class BookCreateResponse
    {
        public Guid StudentId { get; set; }
        public string BookName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
