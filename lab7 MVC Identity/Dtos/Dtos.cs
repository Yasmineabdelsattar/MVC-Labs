namespace lab7_MVC_Identity.Dtos;

public record LoginDto(string UserName, string Password);
public record RegisterDto(string UserName, string Password, string Email, DateTime DOB);
