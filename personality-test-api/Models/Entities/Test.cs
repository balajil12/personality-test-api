using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace personality_test_api.Models.Entities
{
    [Table("Test")]
    public class Test
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Name { get; set; }

        [Column(TypeName = "TEXT")]
        public string Description { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<TestResult> Results { get; set; }
    }
}
