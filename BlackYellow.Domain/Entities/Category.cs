using Dapper.Contrib.Extensions;


namespace BlackYellow.Domain.Entites
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}