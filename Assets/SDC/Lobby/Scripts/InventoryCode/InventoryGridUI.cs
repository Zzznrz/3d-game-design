using UnityEngine;

public class InventoryGridUI: MonoBehaviour   //挂在Inventory Panel 上，负责生成仓库格子并分配物品。
{
    // 格子预制体，格子容器和格子数
    [SerializeField] private GameObject itemSlotPrefab;
    [SerializeField] private Transform content;
    [SerializeField] private int capacity;

    // 在 Inventory 中指定右侧的详情面板
    [SerializeField] private InventoryDetailUI detailUI;

    // 按顺序放入仓库的物品：第一个元素进入第一个格子。
    [SerializeField] private InventoryItemData[] items = new InventoryItemData[0];


    private void Start()
    {
        // 按容量生成格子
        for(int i=0; i<capacity; i++)
        {
            GameObject newSlot = Instantiate(itemSlotPrefab, content);

            //从新格子上取得负责显示图标和处理点击的脚本。
            InventorySlotUI slotUI = newSlot.GetComponent<InventorySlotUI>();

            // 有对应物品就取出：超过物品数量的格子保持为空。
            InventoryItemData item = i < items.Length ? items[i] : null;

            // 把物品和详情面板交给这个格子。
            slotUI.Setup(item, detailUI);

            
        }
    }

}
