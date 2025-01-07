
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;


public class User{

[Key]
public int Id {get; set;}  


[Required(ErrorMessage = "نام و نام خانوادگی را وارد کنید")]
[MaxLength(20, ErrorMessage = "نام و نام خانوادگی نمی تواند بیشتر از 20 کاراکتر باشد")]

public string NameFamily {get; set;}  


[Required(ErrorMessage = "ایمیل را وارد کنید")]
[EmailAddress(ErrorMessage = "ایمیل وارد شده صحیح نیست")]
public string Email {get; set;}  

[Required(ErrorMessage = "رمز عبور را وارد کنید")]
[MinLength(6, ErrorMessage = "رمز عبور نمی تواند کمتر از 6 کاراکتر باشد")]
public string Password {get; set;}  


}