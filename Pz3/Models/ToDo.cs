using System.Data.Linq.Mapping;

namespace Pz3.Models
{
    [Table(Name = "ToDo")]
    public class ToDo
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column] public string Name { get; set; }

        [Column] public string Description { get; set; }

        [Column] public bool IsDone { get; set; }
    }
}