using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace personality_test_api.Models.Entities
{
    [Table("Question")]
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Description { get; set; }

        [ForeignKey("TestId")]
        public Test Test { get; set; }
        public int TestId { get; set; }

        public ICollection<QuestionOption> Options { get; set; }
    }
}
