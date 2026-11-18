using System;
using PropertyCrmLab.Models;
using PropertyCrmLab.Repositories;
using PropertyCrmLab.Data;

using var dbContext = new AppDbContext();
var repository = new PropertyRepository(dbContext);

var newProperty = new Property
{
    Address = "ул. Ленина, д. 10, оф. 402",
    Area = 75.5m,
    RentPrice = 45000m
};

await repository.AddAsync(newProperty);
Console.WriteLine($"[+] Добавлен объект ID: {newProperty.Id}");

var properties = await repository.GetAllAsync();
Console.WriteLine($"\nВсего объектов в БД: {properties.Count}");
foreach (var p in properties)
{
    Console.WriteLine($"- ID: {p.Id}, Адрес: {p.Address}, Площадь: {p.Area} м², Цена: {p.RentPrice} руб.");
}