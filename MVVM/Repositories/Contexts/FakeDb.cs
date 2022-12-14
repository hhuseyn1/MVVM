using MVVM.Models;
using System.Collections.Generic;

namespace MVVM.Repositories.Contexts;

public class FakeDb
{
    public static List<Car> Cars { get; set; } = new()
    {
        new Car { Id = 1, Make = "Mercedes", Model = "S Class" , Year = 2022 },
        new Car { Id = 2, Make = "Nissan", Model = "Skyline", Year = 2001  },
        new Car { Id = 3, Make = "BMW", Model = "e36", Year = 1996 },
    };

}
