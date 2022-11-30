using MVVM.Models;
using System.Collections.Generic;
using System;
using MVVM.Repositories.Abstracts;
using MVVM.Repositories.Contexts;
using System.Linq;

namespace MVVM.Repositories.Concretes;
public class FakeCarRepository : ICarRepository
{
    public void Add(Car entity) => FakeDb.Cars.Add(entity);

    public Car? Get(Func<Car, bool> predicate) => FakeDb.Cars.FirstOrDefault(predicate);

    public List<Car> GetList(Func<Car, bool>? predicate = null) => (predicate is null) switch
    {
        true => FakeDb.Cars,
        false => FakeDb.Cars.Where(predicate).ToList()
    };

    public void Remove(Car entity) => FakeDb.Cars.Remove(entity);

    public void Update(Car entity) => FakeDb.Cars[FakeDb.Cars.IndexOf(entity)] = entity;
}
