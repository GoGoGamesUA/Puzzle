using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public CanvasGroup settingsBorder;  // ����'����� CanvasGroup

    // ����� ��� ����������� SettingsBorder
    public void ShowSettings()
    {
        settingsBorder.alpha = 1f;  // ������ ���� �������
        settingsBorder.interactable = true;  // ���������� �������
        settingsBorder.blocksRaycasts = true;  // ������� ���� ��� �����䳿
    }

    // ����� ��� ���������� SettingsBorder
    public void HideSettings()
    {
        settingsBorder.alpha = 0f;  // ������ ���� ���������
        settingsBorder.interactable = false;  // ����������� �������
        settingsBorder.blocksRaycasts = false;  // ������������ ������� � ������ ����������
    }
}
