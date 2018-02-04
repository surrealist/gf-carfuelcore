using CarFuelCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace CarFuelCore.Services {
  public class UserService : IUserService {

    private readonly IHttpContextAccessor http;
    private readonly UserManager<ApplicationUser> userManager;

    public UserService(IHttpContextAccessor http, UserManager<ApplicationUser> userManager) {
      this.http = http;
      this.userManager = userManager;
    }

    public string CurrentUserId() {
      var user = userManager.FindByEmailAsync(http.HttpContext.User.Identity.Name).Result;
      return user.Id;
    }

    public bool IsLoggedIn() {
      return http.HttpContext.User.Identity.IsAuthenticated;
    }
  }
}
