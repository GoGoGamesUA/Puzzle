using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public CanvasGroup settingsBorder;  // Прив'язуємо CanvasGroup

    // Метод для відображення SettingsBorder
    public void ShowSettings()
    {
        settingsBorder.alpha = 1f;  // Робимо вікно видимим
        settingsBorder.interactable = true;  // Дозволяємо взаємодію
        settingsBorder.blocksRaycasts = true;  // Блокуємо вікно для взаємодії
    }

    // Метод для приховання SettingsBorder
    public void HideSettings()
    {
        settingsBorder.alpha = 0f;  // Робимо вікно невидимим
        settingsBorder.interactable = false;  // Забороняємо взаємодію
        settingsBorder.blocksRaycasts = false;  // Розблоковуємо взаємодію з іншими елементами
    }
}
