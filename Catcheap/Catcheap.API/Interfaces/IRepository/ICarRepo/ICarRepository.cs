﻿using Catcheap.API.Models.CarModels;

namespace Catcheap.API.Interfaces.IRepository.ICarRepo;

public interface ICarRepository
{
    ICollection<Car> GetCars();

    Car GetCar(int carId);

    bool CarExists(int carId);

    bool CreateCar(Car car);

    bool UpdateCar(Car car);

    bool DeleteCar(Car car);

    bool Save();
}
