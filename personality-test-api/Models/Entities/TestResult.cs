using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace personality_test_api.Models.Entities
{
    [Table("TestResult")]
    public class TestResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("TestId")]
        public Test Test { get; set; }
        public int TestId { get; set; }

        [Range(0, 1)]
        public float LessThanEqual { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Conclusion { get; set; }

        [Column(TypeName = "TEXT")]
        public string Description { get; set; }
    }
}
