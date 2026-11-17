using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class InventoryItemData: ScriptableObject
{
    public string itemName;
    public Sprite icon;
    [Min(0)] public int value;
    [TextArea(3, 6)] public string description;

}
