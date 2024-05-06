using System.Text;

namespace INVENTORY_MANAGEMENT.Entity;

public class Product
{
    public int id;
    public string name = string.Empty;
    public string? descriptin = string.Empty;
    public int maxItemsInStock = 0;
    public UnitType unitType {get;set;}
    public int amountInStock {get;private set;}
    public bool isBellowStockThreshold {get;set;}
    
    
    public Product(int id,string name){
        Id = id;
        Name = name;
    }
    public Product(int id):this(id,string.Empty){}

    public Product(int id,string name,string? description,UnitType uType, int maxAmontInStock)
    {
        Id = id;
        Name = name;
        Description = description;
        unitType = uType;
        maxItemsInStock = maxAmontInStock;
        if (amountInStock < 10)
        {
            isBellowStockThreshold = true;
        }
    }

    public int Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }


    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value.Length > 50 ? name[..50]: name;
        }
    }

    public string? Description
    {
        get
        {
            return descriptin;
        }
        set
        {
            if (descriptin == null)
            {
                descriptin = string.Empty;
            }
            else
            {
                descriptin = value.Length > 250 ? value[..250]: value;
            }
        }
    }


    public void increaseStock()
    {
        amountInStock++;
    }

    public void inreaeStock(int amount)
    {
        int newstock = amountInStock + amount;
        if (newstock <= maxItemsInStock )
        {
            amountInStock = amountInStock + amount;
        }else
        {
            amountInStock = maxItemsInStock;
            int extra = newstock - amountInStock;
            Log($"Stock Overflow . Extra : {extra} items could not be stored");
        }

        if (amountInStock > 10)
        {
            isBellowStockThreshold = false;
        }
    }

    private void Decreaseproduct(int items,string reason)
    {
        if (items < amountInStock)
        {
            amountInStock = amountInStock - items;
        }
        else
        {
            amountInStock = 0;
        }
        UpdateLowStock();
        Log(reason);
    }

    public void UseProduct(int items)
    {
        if (items < amountInStock)
        {
            amountInStock = amountInStock - items;
            UpdateLowStock();
            Log($"Amount Is updated. New Stock is {amountInStock}");

        }
        else
        {
            Log($"Not Enough Item for {SimpleProductRepresentation()} \n Amount Available : {amountInStock}\n Requested: {items}");
        }

    }

    private void UpdateLowStock()
    {
        if (amountInStock < 10)
        {
            isBellowStockThreshold = true;
        }
    }

    private void Log(string message)
    {
        Console.WriteLine(message);
    }

    private string SimpleProductRepresentation()
    {
        return $"Product {Id} {name}";
    }

    public string DisplayDetailsShort()
    {
        return $"Product Id {Id}\n Product Name {name}\n Amount in Stock {amountInStock} ";
    }

    public string DisplayDetailsFull()
    {
        StringBuilder sb = new();
        sb.Append($"ID :{id}\n NAME : {name}\n DESCRIPTION : {descriptin}\n STOCK: {amountInStock}\n ");
        if (isBellowStockThreshold)
        {
            sb.Append("LOW ON STOCK !!!!");
        }
        return sb.ToString();
    }
    
}