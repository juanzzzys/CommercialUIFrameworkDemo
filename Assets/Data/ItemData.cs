public class ItemData
{
    public int id;
    public string itemName;
    public int count;
    public ItemQuality quality;
    public ItemData(int id, string itemName, int count, ItemQuality quality)
    {
        this.id = id;
        this.itemName = itemName;
        this.count = count;
        this.quality = quality;
    }
}