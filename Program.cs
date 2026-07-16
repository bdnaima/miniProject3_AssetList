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
            Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine(asset);

        Console.ResetColor();
    }
}

// Show asset details
static void ShowAssetDetails(MyDbContext context, int id)
{
    var asset = context.Assets.FirstOrDefault(a => a.AssetId == id);

    if (asset == null)
    {
        Console.WriteLine("Asset not found.");
        return;
    }

    if (asset.Status == "RED")
        Console.ForegroundColor = ConsoleColor.Red;
    else if (asset.Status == "YELLOW")
        Console.ForegroundColor = ConsoleColor.Yellow;
    else
        Console.ForegroundColor = ConsoleColor.Green;

    Console.WriteLine();
    Console.WriteLine("========== ASSET DETAILS ==========");
    Console.WriteLine($"ID:                 {asset.AssetId}");
    Console.WriteLine($"Type:               {asset.Type}");
    Console.WriteLine($"Brand:              {asset.Brand}");
    Console.WriteLine($"Model:              {asset.Model}");
    Console.WriteLine($"Office:             {asset.Office}");
    Console.WriteLine($"Purchase Price:     {asset.PriceUSD} USD");
    Console.WriteLine($"Local Price:        {asset.GetLocalPrice():0.00} {asset.Currency}");
    Console.WriteLine($"Purchase Date:      {asset.PurchaseDate:yyyy-MM-dd}");
    Console.WriteLine($"Warranty Expires:   {asset.WarrantyExpirationDate:yyyy-MM-dd}");
    Console.WriteLine($"Serial Number:      {asset.SerialNumber}");
    Console.WriteLine($"Employee:           {asset.AssignedEmployee ?? "-"}");
    Console.WriteLine($"Status:             {asset.Status}");
    Console.WriteLine("===================================");

    Console.ResetColor();
}

// Add asset
static void AddAsset(MyDbContext context)
{
    Console.Write("Brand: ");
    string brand = Console.ReadLine() ?? "";

    Console.Write("Model: ");
    string model = Console.ReadLine() ?? "";

    Console.Write("Purchase date (yyyy-MM-dd): ");
    DateTime purchaseDate = DateTime.Parse(Console.ReadLine()!);

    Console.Write("Price USD: ");
    double price = double.Parse(Console.ReadLine()!);

    Console.Write("Office: ");
    string office = Console.ReadLine() ?? "";

    Console.Write("Serial number: ");
    string serialNumber = Console.ReadLine() ?? "";

    Console.Write("Warranty expiration date (yyyy-MM-dd): ");
    DateTime warrantyDate = DateTime.Parse(Console.ReadLine()!);

    Console.Write("Assigned employee (optional): ");
    string? employee = Console.ReadLine();


    var asset = new Computer(
        brand,
        model,
        purchaseDate,
        price,
        office,
        serialNumber,
        warrantyDate,
        employee
    );

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

    int id = int.Parse(Console.ReadLine()!);


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
    asset.Brand = Console.ReadLine() ?? "";


    Console.Write("New model: ");
    asset.Model = Console.ReadLine() ?? "";


    context.SaveChanges();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Asset updated");
    Console.ResetColor();
}

// Delete asset
static void DeleteAsset(MyDbContext context)
{
    Console.Write("Enter Asset ID: ");

    int id = int.Parse(Console.ReadLine()!);


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