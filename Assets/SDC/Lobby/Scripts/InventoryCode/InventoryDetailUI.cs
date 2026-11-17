using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InventoryDetailUI : MonoBehaviour   // 把这个脚本挂在Item Detail Panel 上，负责显示选中物品的详情。
{
    // 在 Inspector 中分别拖入详情面板里的图标和三个文字对象。
    [SerializeField] private Image itemIcon;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text itemValue;
    [SerializeField] private TMP_Text itemDescription;

    // 当玩家点击一个物品格子时，用该物品的数据更新详情面板。
    public void Show(InventoryItemData item)
    {
        // 如果没有传入物品，就停止，避免空数据报错。
        if (item == null) return;

        //显示物品名称，价值和介绍
        itemName.text = item.itemName;
        itemValue.text = $"Value: {item.value}";
        itemDescription.text = item.description;

        // 显示物品图标： 如果没有物品图标，就隐藏白色的图标方块。
        itemIcon.sprite = item.icon;
        itemIcon.gameObject.SetActive(item.icon != null);
    }
}
