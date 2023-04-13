using System.Collections.Generic;

public class Inventory {
    private List<Item> item_list;

    public Inventory() {
        item_list = new List<Item>();
    }

    //TODO Maybe check if full?
    public void AddItem(Item item) {
        item_list.Add(item);
    }
}
