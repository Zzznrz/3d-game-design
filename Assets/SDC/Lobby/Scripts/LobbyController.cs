using UnityEngine;
using UnityEngine.UI;

namespace SDC.Lobby
{
    [ExecuteAlways]
    public class LobbyController : MonoBehaviour
    {
        private Font chineseFont;

        private void OnEnable()
        {
            string[] fontNames = { "PingFang SC", "Microsoft YaHei", "Noto Sans CJK SC", "Arial" };
            chineseFont = Font.CreateDynamicFontFromOSFont(fontNames, 36);

            Text[] texts = GetComponentsInChildren<Text>(true);
            foreach (Text text in texts)
            {
                text.font = chineseFont;
            }
        }

        public void StartGame()
        {
            Debug.Log("Start clicked. Gameplay is not available yet.");
        }

        public void OpenInventory()
        {
            Debug.Log("Inventory clicked. Inventory is not available yet.");
        }
    }
}
