using System;
using System.Collections.Generic;
using System.Text;

namespace CarFuelCore.Services
{
  public interface IUserService {

    bool IsLoggedIn();
    string CurrentUserId();

  }
}
