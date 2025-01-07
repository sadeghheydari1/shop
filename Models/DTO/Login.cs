using System.ComponentModel.DataAnnotations;


    public class DLogin
    {
[Required(ErrorMessage = "ایمیل را وارد کنید")]
[EmailAddress(ErrorMessage = "ایمیل وارد شده صحیح نیست")]
        public string Email { get; set; }

        [Required(ErrorMessage = "رمز عبور را وارد کنید")]
        [MinLength(6, ErrorMessage = "رمز عبور نمی تواند کمتر از 6 کاراکتر باشد")]
        public string Password { get; set; }
    }