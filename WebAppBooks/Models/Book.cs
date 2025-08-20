using System.ComponentModel.DataAnnotations;

namespace WebAppBooks.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required, StringLength(150)]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required, StringLength(20)]
        [Display(Name = "ISBN")]
        public string Isbn { get; set; }

        [Required, Display(Name = "Publication Date")]
        [DataType(DataType.Date)]
        [FutureDateNotAllowed(ErrorMessage = "Publication date cannot be in the future.")]
        public DateTime? PublicationDate { get; set; }

        // Custom validation attribute
        public class FutureDateNotAllowedAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value is DateTime date)
                {
                    return date <= DateTime.Today;
                }
                return true;
            }
        }
    }
}
