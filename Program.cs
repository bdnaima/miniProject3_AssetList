// Program.cs

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

List<Asset> assets = new List<Asset>();

// Computers
assets.Add(new Computer(
    1,
    "Apple",
    "MacBook Pro",
    new DateTime(2022, 3, 15),
    1500,
    "Sweden"
));

assets.Add(new Computer(
    1,
    "Apple",
    "MacBook Pro",
    new DateTime(2023, 8, 1),
    1500,
    "Sweden"
));

assets.Add(new Computer(
    2,
    "Lenovo",
    "ThinkPad X1",
    new DateTime(2023, 11, 1),
    1200,
    "USA"
));


// Phones
assets.Add(new MobilePhone(
    3,
    "Samsung",
    "Galaxy S23",
    new DateTime(2025, 1, 1),
    900,
    "Turkey"
));

assets.Add(new MobilePhone(
    5,
    "Samsung",
    "Galaxy S23",
    new DateTime(2022, 9, 1),
    850,
    "Turkey"
));

assets.Add(new MobilePhone(
    6,
    "Nokia",
    "XR20",
    new DateTime(2026, 3, 1),
    600,
    "USA"
));


// LEVEL 3 SORTING

var sortedAssets = assets
    .OrderBy(asset => asset.Office)
    .ThenBy(asset => asset.PurchaseDate)
    .ToList();

Asset.ShowAllAssets(sortedAssets);