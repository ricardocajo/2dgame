public abstract class Item
{
    // Declare protected abstract properties
    protected abstract string type { get; }

    public virtual string GetItemType()
    {
        return type;
    }
}