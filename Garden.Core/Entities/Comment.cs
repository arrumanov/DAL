using System;

namespace Garden.Core.Entities
{
    public class Comment : Entity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
