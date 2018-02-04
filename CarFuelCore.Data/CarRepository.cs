using CarFuelCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarFuelCore.Data {

  public class CarRepository : RepositoryBase<Car> {

    public CarRepository(DbContext context) : base(context) {
      //
    }

  }

}
