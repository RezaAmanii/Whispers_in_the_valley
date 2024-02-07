using System;

[System.Serializable]
public class Item
{
    // Attributes

    public int itemID;
    public String itemName;
    // Public Sprite itemSprite;
    public String spriteName;




    // Constructor

    public Item(int id, String name, String sName)
    {
        id = this.itemID;
        name = this.itemName;
        sName = this.spriteName;

    }
}
