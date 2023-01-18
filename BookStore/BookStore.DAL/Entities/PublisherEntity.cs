using BookStore.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Entities
{
    public class PublisherEntity : IBaseEntity<string>
    {
        public string Id { get; set ; }

        public string Name { get; set ; }

        public string Description { get; set; }

        public bool IsDeleted { get; set ; }

        public ICollection<BookEntity> Books { get; set; }
    }
}
