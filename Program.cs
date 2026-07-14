// Program.cs
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

using var context = new MyDbContext(configuration);

context.Assets.Add(new Computer(
    "Apple",
    "MacBook Pro",
    new DateTime(2022, 3, 15),
    1500,
    "Sweden"));

context.Assets.Add(new Computer(
    "Lenovo",
    "ThinkPad X1",
    new DateTime(2023, 11, 1),
    1200,
    "USA"));

context.Assets.Add(new MobilePhone(
    "Samsung",
    "Galaxy S23",
    new DateTime(2025, 1, 1),
    900,
    "Turkey"));

context.SaveChanges();

Console.WriteLine("Asset List");
Console.WriteLine("------------------------------------------------------------------------------------------------");

Console.Write("ID".PadRight(6));
Console.Write("Type".PadRight(15));
Console.Write("Brand".PadRight(15));
Console.Write("Model".PadRight(20));
Console.Write("Office".PadRight(12));
Console.Write("Price".PadRight(18));
Console.Write("Purchase Date".PadRight(18));
Console.Write("Age".PadRight(8));
Console.Write("Status");

Console.WriteLine();
Console.WriteLine("------------------------------------------------------------------------------------------------");


var assets = context.Assets
    .OrderBy(a => a.Office)
    .ThenBy(a => a.PurchaseDate)
    .ToList();

Asset.ShowAllAssets(assets);