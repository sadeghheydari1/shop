
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;


public class User{

[Key]
public int Id {get; set;}  
public string NameFamily {get; set;}  

public string Email {get; set;}  

public string Password {get; set;}  


}