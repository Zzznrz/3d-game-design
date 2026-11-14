using UnityEngine;

namespace SDC.Lobby
{
    public class CharacterSwitcher : MonoBehaviour
    {
        public GameObject[] characters;
        private int current;

        private void Start()
        {
            Show(0);
        }

        public void Next()
        {
            Show(current + 1);
        }

        public void Previous()
        {
            Show(current - 1);
        }

        private void Show(int index)
        {
            if (characters.Length == 0) return;
            current = (index + characters.Length) % characters.Length;
            for (int i = 0; i < characters.Length; i++)
                characters[i].SetActive(i == current);
        }
    }
}
