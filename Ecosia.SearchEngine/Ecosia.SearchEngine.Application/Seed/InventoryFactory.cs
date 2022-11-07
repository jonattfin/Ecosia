namespace Ecosia.SearchEngine.Application.Seed;

public class InventoryFactory
{
    public IInventory CreateInventory() => new MemoryInventory();
}