// Program.cs
using var context = new MyDbContext();

bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("Smart Asset Tracking System");
    Console.WriteLine("--------------------------");
    Console.WriteLine("1. Show all assets");
    Console.WriteLine("2. Add asset");
    Console.WriteLine("3. Update asset");
    Console.WriteLine("4. Delete asset");
    Console.WriteLine("5. Exit");

    Console.Write("Choose option: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            ShowAssets(context);
            break;

        case "2":
            AddAsset(context);
            break;

        case "3":
            UpdateAsset(context);
            break;

        case "4":
            DeleteAsset(context);
            break;

        case "5":
            running = false;
            break;

        default:
            Console.WriteLine("Invalid choice");
            break;
    }
}

static void ShowAssets(MyDbContext context)
{
    Console.WriteLine();
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
}

static void AddAsset(MyDbContext context)
{
    Console.WriteLine("Add asset selected");
}

static void UpdateAsset(MyDbContext context)
{
    Console.WriteLine("Update asset selected");
}

static void DeleteAsset(MyDbContext context)
{
    Console.WriteLine("Delete asset selected");
}