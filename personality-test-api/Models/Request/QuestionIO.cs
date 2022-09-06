using System.ComponentModel.DataAnnotations;

namespace personality_test_api.Models.Request
{
    public class QuestionIO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Question should not be empty")]
        public string Question { get; set; }

        public List<OptionIO> Options { get; set; }
    }

    public class OptionIO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Option should not be empty")]
        public string Option { get; set; }

        /// <summary>
        /// Introvert / Extrovert ratio
        /// </summary>
        public float Ratio { get; set; }
    }
}
