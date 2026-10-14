using Microsoft.AspNetCore.Mvc;
using InfoTechAcademy.Models;
using System.Net;
using System.Net.Mail;

namespace InfoTechAcademy.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index() => View();
        public IActionResult Courses() => View();

        [HttpGet]
        public IActionResult Admission() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Admission(Admission admission)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var emailSettings = _configuration.GetSection("EmailSettings");
                    string senderEmail = emailSettings["SenderEmail"];
                    string senderPassword = emailSettings["SenderPassword"];
                    string smtpServer = emailSettings["SmtpServer"];
                    int port = int.Parse(emailSettings["Port"]);

                    string subject = "New Admission Form Submitted - InfoTech Academy[span_4](start_span)[span_4](end_span)";
                    string body = $@"
                        <h3>New Student Admission Details</h3>
                        <p><strong>Full Name:</strong> {admission.FullName}</p>
                        <p><strong>Father Name:</strong> {admission.FatherName}</p>
                        <p><strong>Date of Birth:</strong> {admission.DateOfBirth.ToShortDateString()}</p>
                        <p><strong>Gender:</strong> {admission.Gender}</p>
                        <p><strong>CNIC / B-Form:</strong> {admission.CnicOrBForm}</p>
                        <p><strong>WhatsApp Number:</strong> {admission.WhatsAppNumber}</p>
                        <p><strong>Contact Number:</strong> {admission.ContactNumber}</p>
                        <p><strong>Email Address:</strong> {admission.Email}</p>
                        <p><strong>Address:</strong> {admission.Address}</p>
                        <p><strong>Qualification:</strong> {admission.Qualification}</p>
                        <hr/>
                        <p><strong>Selected Course:</strong> {admission.SelectedCourse}</p>
                        <p><strong>Payment Status:</strong> {admission.PaymentStatus}</p>
                        <p><strong>Payment Method:</strong> {admission.PaymentMethod}</p>
                        <p><strong>JazzCash Transaction ID:</strong> {admission.TransactionId}</p>
                        <p><strong>Submission Date:</strong> {admission.SubmissionDate}</p>
                    ";

                    var message = new MailMessage();
                    message.From = new MailAddress(senderEmail, "InfoTech Academy Admissions[span_5](start_span)[span_5](end_span)");
                    message.To.Add(senderEmail);
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = true;

                    using (var client = new SmtpClient(smtpServer, port))
                    {
                        client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                        client.EnableSsl = true;
                        client.Send(message);
                    }

                    TempData["SuccessMessage"] = "Aapka admission form kamyaabi ke sath submit ho gaya hai aur email director tak pohch gayi hai!";
                }
                catch (Exception ex)
                {
                    TempData["SuccessMessage"] = "Form submit ho gaya hai, lekin email bhejte waqt error aaya: " + ex.Message;
                }

                return RedirectToAction(nameof(Admission));
            }
            return View(admission);
        }

        public IActionResult Rules() => View();
    }
}