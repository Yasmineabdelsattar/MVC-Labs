using lab7_MVC_Identity.Dtos;
using lab7_MVC_Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace lab7_MVC_Identity.Controllers;

public class UsersController : Controller
{
    private readonly UserManager<CustomUser> _userManager;
    private readonly SignInManager<CustomUser> _signInManager;

    public UsersController(UserManager<CustomUser> userManager,
        SignInManager<CustomUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    #region Login

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto credentials)
    {
        var user = await _userManager.FindByNameAsync(credentials.UserName);
        if (user is null)
        {
            //TODO Add Errors To ModelState
            //ModelState.AddModelError(string.Empty, user.Errors.First().Description);
            ModelState.AddModelError(string.Empty, "username or password is wrong");
            return View();
        }

        var isAuthenticated = await _userManager.CheckPasswordAsync(user,
            credentials.Password);
        if (!isAuthenticated)
        {
            //TODO Add Errors To ModelState
            ModelState.AddModelError(string.Empty, "erorr");
            return View();
        }

        var claims = await _userManager.GetClaimsAsync(user);
        await _signInManager.SignInWithClaimsAsync(user, true, claims);

        return RedirectToAction("Index", "Home");
    }

    #endregion

    #region Register

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var user = new CustomUser
        {
            UserName = registerDto.UserName,
            Email = registerDto.Email,
            DateOfBirth = registerDto.DOB
        };
        var creationResult = await _userManager.CreateAsync(user, registerDto.Password); //cause its hashed
        if (!creationResult.Succeeded)
        {
            ModelState.AddModelError(string.Empty, creationResult.Errors.First().Description);
            return View();
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, "User"),
        };

        await _userManager.AddClaimsAsync(user, claims);

        return RedirectToAction("Login");
    }

    #endregion

    #region Logout
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    #endregion
    public IActionResult Index()
    {
        return View();
    }
}
