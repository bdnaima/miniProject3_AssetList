// Asset.cs
public abstract class Asset
{
    // Properties
    public int AssetId { get; set; }

    public string Type { get; set; } = "";

    public string Brand { get; set; } = "";

    public string Model { get; set; } = "";

    public DateTime PurchaseDate { get; set; }

    public double PriceUSD { get; set; }

    public string Office { get; set; } = "";

    public string Currency { get; set; } = "";

    public string SerialNumber { get; set; } = "";

    public string? AssignedEmployee { get; set; }

    public DateTime WarrantyExpirationDate { get; set; }


    // Constructor
    protected Asset()
    {
    }
    protected Asset(
        string type,
        string brand,
        string model,
        DateTime purchaseDate,
        double priceUSD,
        string office,
        string serialNumber,
        DateTime warrantyExpirationDate,
        string? assignedEmployee = null
        )

    {
        Type = type;
        Brand = brand;
        Model = model;
        PurchaseDate = purchaseDate;
        PriceUSD = priceUSD;
        Office = office;
        SerialNumber = serialNumber;
        WarrantyExpirationDate = warrantyExpirationDate;
        AssignedEmployee = assignedEmployee;

        // Set currency depending on office
        switch (Office)
        {
            case "Sweden":
                Currency = "SEK";
                break;

            case "USA":
                Currency = "USD";
                break;

            case "Germany":
                Currency = "EUR";
                break;

            case "Turkey":
                Currency = "TRY";
                break;
        }
    }


    // Convert USD to local currency
    public double GetLocalPrice()
    {
        switch (Currency)
        {
            case "SEK":
                return PriceUSD * 10.5;

            case "EUR":
                return PriceUSD * 0.92;

            case "TRY":
                return PriceUSD * 32;

            default:
                return PriceUSD;
        }
    }


    // Asset age
    public int GetAssetAge()
    {
        return DateTime.Now.Year - PurchaseDate.Year;
    }

    public string Status
    {
        get => GetStatus();
    }
    // End-of-life status
    public string GetStatus()
    {
        DateTime endOfLife = PurchaseDate.AddYears(3);

        double daysLeft = (endOfLife - DateTime.Now).TotalDays;
        if (daysLeft < 90)
            return "RED";

        if (daysLeft < 180)
            return "YELLOW";

        return "GREEN";
    }


    // Print asset
    public override string ToString()
    {
        return
            $"{AssetId,-4}" +
            $"{Type,-10}" +
            $"{Brand,-12}" +
            $"{Model,-18}" +
            $"{Office,-10}" +
            $"{($"{GetLocalPrice():0.00} {Currency}"),-17}" +
            $"{Status,-8}" +
            $"{SerialNumber,-12}" +
            $"{(AssignedEmployee ?? "-"),-12}" +
            $"{WarrantyExpirationDate:yyyy-MM-dd}";
    }


    // Show all assets
    public static void ShowAllAssets(List<Asset> assets)
    {
        foreach (Asset asset in assets)
        {
            if (asset.Status == "RED")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (asset.Status == "YELLOW")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.WriteLine(asset);

            Console.ResetColor();
        }
    }
}

public class Computer : Asset
{
    public Computer()
    {
    }

    public Computer(
        string brand,
        string model,
        DateTime purchaseDate,
        double priceUSD,
        string office,
        string serialNumber,
        DateTime warrantyExpirationDate,
        string? assignedEmployee = null)
        : base(
            "Computer",
            brand,
            model,
            purchaseDate,
            priceUSD,
            office,
            serialNumber,
            warrantyExpirationDate,
            assignedEmployee
            )
    {
    }
}

public class MobilePhone : Asset
{
    public MobilePhone()
    {
    }

    public MobilePhone(
        string brand,
        string model,
        DateTime purchaseDate,
        double priceUSD,
        string office,
        string serialNumber,
        DateTime warrantyExpirationDate,
        string? assignedEmployee = null)
        : base(
            "Mobile Phone",
            brand,
            model,
            purchaseDate,
            priceUSD,
            office,
            serialNumber,
            warrantyExpirationDate,
            assignedEmployee)
    {
    }
}