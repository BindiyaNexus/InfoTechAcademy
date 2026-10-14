using System.ComponentModel.DataAnnotations;

namespace InfoTechAcademy.Models
{
    public class Admission
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Student Full Name is required")]
        [Display(Name = "Student Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Father / Guardian Name is required")]
        [Display(Name = "Father / Guardian Name")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "CNIC or B-Form Number is required")]
        [Display(Name = "CNIC / B-Form Number")]
        public string CnicOrBForm { get; set; }

        [Required(ErrorMessage = "WhatsApp Number is required")]
        [Display(Name = "WhatsApp Number")]
        public string WhatsAppNumber { get; set; }

        [Required(ErrorMessage = "Contact Number is required")]
        [Display(Name = "Mobile / Contact Number")]
        public string ContactNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Residential Address is required")]
        [Display(Name = "Residential Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Qualification is required")]
        [Display(Name = "Last Educational Qualification")]
        public string Qualification { get; set; }

        [Required(ErrorMessage = "Please select a course")]
        [Display(Name = "Select Course")]
        public string SelectedCourse { get; set; }

        [Required(ErrorMessage = "Please select payment status")]
        [Display(Name = "Payment Status")]
        public string PaymentStatus { get; set; }

        [Required(ErrorMessage = "Please select payment method")]
        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; }

        [Required(ErrorMessage = "Transaction ID is required")]
        [Display(Name = "JazzCash Transaction ID / Reference No.")]
        public string TransactionId { get; set; }

        public DateTime SubmissionDate { get; set; } = DateTime.Now;
    }
}