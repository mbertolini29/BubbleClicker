using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //[SerializeField] private FishTankManager fishTankManager;
    [SerializeField] private Text levelText;

    //private void OnEnable()
    //{
    //    fishTankManager.OnLevelUp += UpdateLevelUI;
    //}

    //private void OnDisable()
    //{
    //    fishTankManager.OnLevelUp -= UpdateLevelUI;
    //}

    //private void Start()
    //{
    //    // Mostrar nivel inicial
    //    UpdateLevelUI(fishTankManager.CurrentLevel);
    //}

    //private void UpdateLevelUI(int newLevel)
    //{
    //    levelText.text = $"Level {newLevel}";
    //    Debug.Log($"UIManager: Actualizado a Level {newLevel}");
    //}
}
