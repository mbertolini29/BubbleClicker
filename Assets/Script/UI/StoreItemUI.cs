using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BubbleClicker
{
    public class StoreItemUI : MonoBehaviour
    {
        [SerializeField] private Image fishImage;
        [SerializeField] private TMP_Text costText;
        [SerializeField] private Button buyButton;

        private int index;
        private StoreManager store;

        public void Init(StoreManager storeManager, int i)
        {
            store = storeManager;
            index = i;

            buyButton.onClick.RemoveAllListeners();
            buyButton.onClick.AddListener(() => store.BuyFish(index));
        }

        public void SetData(FishSO fishSO, int tankLevel)
        {
            if (fishSO == null)
            {
                fishImage.enabled = false;
                costText.text = "---";
                return;
            }

            fishImage.enabled = true;
            fishImage.sprite = fishSO.icon;
            costText.text = fishSO.cost.ToString("0");
        }
    }
}
