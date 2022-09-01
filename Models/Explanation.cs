using System.ComponentModel.DataAnnotations;

namespace DawaAPI.Models
{

    public class Explanation
    {
        public int Id { get; set; }
        public int AyahId { get; set; }
        public virtual ExplanationSource Source { get; set; }
        public string ExplanationText { get; set; }

    }
}
