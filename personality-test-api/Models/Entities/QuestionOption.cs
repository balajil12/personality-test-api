using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace personality_test_api.Models.Entities
{
    [Table("QuestionOption")]
    public class QuestionOption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
        public int QuestionId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string OptionText { get; set; }

        /// <summary>
        /// introvert / extrovert ratio
        /// </summary>
        [Range(0, 1)]
        public float Ratio { get; set; }
    }
}
