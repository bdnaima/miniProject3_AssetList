// Program.cs
using var context = new MyDbContext();

context.Assets.Add(new Computer(
    "Apple",
    "MacBook Pro",
    new DateTime(2022, 3, 15),
    1500,
    "Sweden",
    "SN123456",
    new DateTime(2025, 3, 15),
    "Alice"));

context.Assets.Add(new Computer(
    "Lenovo",
    "ThinkPad X1",
    new DateTime(2023, 11, 1),
    1200,
    "USA",
    "SN654321",
    new DateTime(2026, 11, 1),
    "Bob"));

context.Assets.Add(new MobilePhone(
    "Samsung",
    "Galaxy S23",
    new DateTime(2025, 1, 1),
    900,
    "Turkey",
    "SN987654",
    new DateTime(2028, 1, 1),
    "Charlie"));

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
Console.Write("Status".PadRight(10));
Console.Write("Serial".PadRight(15));
Console.Write("Employee".PadRight(20));
Console.Write("Warranty".PadRight(15));

Console.WriteLine();
Console.WriteLine("------------------------------------------------------------------------------------------------");


var assets = context.Assets
    .OrderBy(a => a.Office)
    .ThenBy(a => a.PurchaseDate)
    .ToList();

Asset.ShowAllAssets(assets);