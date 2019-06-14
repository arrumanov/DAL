using Garden.Core.Enums;
using System;
using System.Collections.Generic;

namespace Garden.Core.Entities
{
    public class Article : Entity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Content { get; set; }

        public DateTime Date { get; set; }

        public CategoryTypes CategoryType { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
