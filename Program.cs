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
    Console.WriteLine("5. Show reports");
    Console.WriteLine("6. Exit");


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
            ShowReports(context);
            break;

        case "6":
            running = false;
            break;

        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid choice");
            Console.ResetColor();
            break;
    }
}


// CRUD operations:

// Show all assets
static void ShowAssets(MyDbContext context)
{
    var assets = context.Assets
        .OrderBy(a => a.Type)
        .ThenBy(a => a.PurchaseDate)
        .ToList();

    Console.WriteLine();
    Console.WriteLine("==============================================================================================================");

    Console.WriteLine(
        $"{"ID",-4}" +
        $"{"Type",-10}" +
        $"{"Brand",-12}" +
        $"{"Model",-18}" +
        $"{"Office",-10}" +
        $"{"Price",-17}" +
        $"{"Status",-8}" +
        $"{"Serial",-12}" +
        $"{"Employee",-12}" +
        $"{"Warranty",-12}");

    Console.WriteLine("==============================================================================================================");

    foreach (var asset in assets)
    {
        if (asset.Status == "RED")
            Console.ForegroundColor = ConsoleColor.Red;
        else if (asset.Status == "YELLOW")
            Console.ForegroundColor = ConsoleColor.Yellow;
        else
            Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine(asset);

        Console.ResetColor();
    }
}

// Add asset
static void AddAsset(MyDbContext context)
{
    Console.WriteLine("Choose asset type:");
    Console.WriteLine("1. Computer");
    Console.WriteLine("2. Mobile");

    string? typeChoice = Console.ReadLine();
    Console.Write("Brand: ");
    string brand = Console.ReadLine() ?? "";

    Console.Write("Model: ");
    string model = Console.ReadLine() ?? "";

    Console.Write("Purchase date (yyyy-MM-dd): ");
    if (!DateTime.TryParse(Console.ReadLine(), out DateTime purchaseDate))
    {
        Console.WriteLine("Invalid date. Include in this format: yyyy-MM-dd");
        return;
    }

    Console.Write("Price USD: ");
    if (!double.TryParse(Console.ReadLine(), out double price))
    {
        Console.WriteLine("Invalid price.");
        return;
    }

    Console.Write("Office: ");
    Console.WriteLine("Sweden");
    Console.WriteLine("USA");
    Console.WriteLine("Germany");
    Console.WriteLine("Turkey");
    string office = Console.ReadLine() ?? "";

    while (
    office != "Sweden" &&
    office != "USA" &&
    office != "Germany" &&
    office != "Turkey")
    {
        Console.WriteLine("Invalid office. Choose Sweden, USA, Germany or Turkey:");
        office = Console.ReadLine() ?? "";
    }

    Console.Write("Serial number: ");
    string serialNumber = Console.ReadLine() ?? "";

    Console.Write("Warranty expiration date (yyyy-MM-dd): ");
    if (!DateTime.TryParse(Console.ReadLine(), out DateTime warrantyDate))
    {
        Console.WriteLine("Invalid warranty date. Include in this format: yyyy-MM-dd");
        return;
    }

    Console.Write("Assigned employee (optional): ");
    string? employee = Console.ReadLine();


    Asset asset;

    if (typeChoice == "2")
    {
        asset = new MobilePhone(
            brand,
            model,
            purchaseDate,
            price,
            office,
            serialNumber,
            warrantyDate,
            employee);
    }
    else
    {
        asset = new Computer(
            brand,
            model,
            purchaseDate,
            price,
            office,
            serialNumber,
            warrantyDate,
            employee);
    }

    context.Assets.Add(asset);

    context.SaveChanges();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Asset added!");
    Console.ResetColor();
}

// Update asset
static void UpdateAsset(MyDbContext context)
{
    Console.Write("Enter Asset ID: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid ID.");
        Console.ResetColor();
        return;
    }

    var asset = context.Assets
        .FirstOrDefault(a => a.AssetId == id);

    if (asset == null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Asset not found");
        Console.ResetColor();
        return;
    }

    Console.Write("New brand: ");
    asset.Brand = Console.ReadLine() ?? asset.Brand;

    Console.Write("New model: ");
    asset.Model = Console.ReadLine() ?? asset.Model;

    Console.Write("New office: ");
    asset.Office = Console.ReadLine() ?? asset.Office;

    asset.UpdateCurrency();

    Console.Write("New price USD: ");
    if (double.TryParse(Console.ReadLine(), out double price))
    {
        asset.PriceUSD = price;
    }

    Console.Write("New assigned employee: ");
    asset.AssignedEmployee = Console.ReadLine();

    Console.Write("New warranty expiration date (yyyy-MM-dd): ");
    if (DateTime.TryParse(Console.ReadLine(), out DateTime warrantyDate))
    {
        asset.WarrantyExpirationDate = warrantyDate;
    }

    context.SaveChanges();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Asset updated");
    Console.ResetColor();
}

// Delete asset
static void DeleteAsset(MyDbContext context)
{
    Console.Write("Enter Asset ID: ");

    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Invalid ID.");
        return;
    }


    var asset = context.Assets
        .FirstOrDefault(a => a.AssetId == id);


    if (asset == null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Asset not found");
        Console.ResetColor();
        return;
    }


    context.Assets.Remove(asset);

    context.SaveChanges();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Asset deleted");
    Console.ResetColor();
}

// Reports
static void ShowReports(MyDbContext context)
{
    Console.WriteLine();
    Console.WriteLine("========== REPORTS ==========");
    Console.WriteLine();

    Console.WriteLine("1. Asset count per office");
    Console.WriteLine("2. Total value per office");
    Console.WriteLine("3. Assets close to expiration");
    Console.WriteLine("4. Most expensive assets");

    Console.Write("Choose report: ");

    string? choice = Console.ReadLine();


    switch (choice)
    {
        case "1":
            AssetCountPerOffice(context);
            break;

        case "2":
            TotalValuePerOffice(context);
            break;

        case "3":
            ExpiringAssets(context);
            break;

        case "4":
            MostExpensiveAssets(context);
            break;

        default:
            Console.WriteLine("Invalid choice");
            break;
    }
}

// Asset count per office
static void AssetCountPerOffice(MyDbContext context)
{
    Console.WriteLine();
    Console.WriteLine("====== ASSET COUNT PER OFFICE ======");


    var report = context.Assets
        .GroupBy(a => a.Office)
        .Select(g => new
        {
            Office = g.Key,
            Count = g.Count()
        });


    foreach (var item in report)
    {
        Console.WriteLine($"{item.Office}: {item.Count} assets");
    }
}

// Total value per office
static void TotalValuePerOffice(MyDbContext context)
{
    Console.WriteLine();
    Console.WriteLine("====== TOTAL VALUE PER OFFICE ======");

    var assets = context.Assets.ToList();

    var report = assets
        .GroupBy(a => a.Office)
        .Select(g => new
        {
            Office = g.Key,
            TotalValue = g.Sum(a => a.GetLocalPrice())
        });

    foreach (var item in report)
    {
        Console.WriteLine(
            $"{item.Office}: {item.TotalValue:0.00}");
    }
}

// Expiring assets
static void ExpiringAssets(MyDbContext context)
{
    Console.WriteLine();
    Console.WriteLine("====== EXPIRING ASSETS ======");

    var assets = context.Assets
        .ToList()
        .Where(a => a.Status != "GREEN")
        .ToList();

    foreach (var asset in assets)
    {
        Console.WriteLine(
            $"{asset.Brand} {asset.Model} - {asset.Status}");
    }
}

static void MostExpensiveAssets(MyDbContext context)
{
    Console.WriteLine();
    Console.WriteLine("====== MOST EXPENSIVE ASSETS ======");

    var assets = context.Assets
        .OrderByDescending(a => a.PriceUSD)
        .Take(5)
        .ToList();

    foreach (var asset in assets)
    {
        Console.WriteLine(asset);
    }
}