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
            string office)

    {
        Type = type;
        Brand = brand;
        Model = model;
        PurchaseDate = purchaseDate;
        PriceUSD = priceUSD;
        Office = office;

        // Set currency depending on office
        switch (Office)
        {
            case "Sweden":
                Currency = "SEK";
                break;

            case "USA":
                Currency = "USD";
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

        // Less than 3 months left
        if (daysLeft < 90)
        {
            return "RED";
        }

        // Less than 6 months left
        else if (daysLeft < 180)
        {
            return "YELLOW";
        }

        else
        {
            return "OK";
        }
    }


    // Print asset
    public override string ToString()
    {
        return
            $"{AssetId.ToString().PadRight(6)}" +
            $"{Type.PadRight(15)}" +
            $"{Brand.PadRight(15)}" +
            $"{Model.PadRight(20)}" +
            $"{Office.PadRight(12)}" +
            $"{(GetLocalPrice().ToString("0.00") + " " + Currency).PadRight(18)}" +
            $"{PurchaseDate.ToString("yyyy-MM-dd").PadRight(18)}" +
            $"{GetAssetAge().ToString().PadRight(8)}" +
            $"{Status}";
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
                Console.ForegroundColor = ConsoleColor.White;
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
        string office)
        : base(
            "Computer",
            brand,
            model,
            purchaseDate,
            priceUSD,
            office)
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
        string office)
        : base(
            "Mobile Phone",
            brand,
            model,
            purchaseDate,
            priceUSD,
            office)
    {
    }
}