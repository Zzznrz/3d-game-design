using UnityEngine;

using UnityEngine.UI;

// 挂在 Item Slot 预制体上，管理单个长裤格子的显示与点击
[RequireComponent(typeof(Button))]
public class InventorySlotUI : MonoBehaviour
{
    // 在 Inspector 中拖入格子里的Item Icon。
    [SerializeField] private Image itemIcon;

    //保存这个格子的物品，以及右侧的详情界面。
    private InventoryItemData item;
    private InventoryDetailUI detailUI;
    private Button button;

    private void Awake()
    {
        // 获取格子根对象上的Button，并注册点击事件。
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }
    private void onClick()
    {
        // 点击空格子不做事，点击有物品的格子则显示详情。
        if(item != null && detailUI != null)
        {
            detailUI.Show(item);
        }
    }
    public void Setup(InventoryItemData newItem,InventoryDetailUI newDetailUI)
    {
        //仓库生成格子时，把对应物品和详情界面交给这个格子。
        item = newItem;
        detailUI = newDetailUI;

        // 有图标就显示，空格子或尚未设置图标时隐藏图标。
        itemIcon.sprite = item != null ? item.icon : null;
        itemIcon.enabled = item != null && item.icon != null;
    }
}
