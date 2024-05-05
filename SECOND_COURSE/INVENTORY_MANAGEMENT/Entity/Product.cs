namespace INVENTORY_MANAGEMENT.Entity;

public class Product {
    private int id;
    private string Name = string.Empty;
    private string? Descriptin  = string.Empty;
    private int maxItemsInStock = 0;
    private UnitType unitType;
    private  int amountInStock = 0;
    private bool isBellowStockThreshold = false;
    
    
    public void increaseProduct()
    {
        amountInStock++;
    }

    
}