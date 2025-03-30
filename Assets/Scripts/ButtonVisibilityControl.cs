using UnityEngine;
using System.Collections;

public class ButtonVisibilityControl : MonoBehaviour
{
    private CanvasGroup buttonCanvasGroup; // ��������� �� CanvasGroup ������

    void Start()
    {
        // �������� ��������� CanvasGroup �� ������ ��'��� ������
        buttonCanvasGroup = GetComponent<CanvasGroup>();

        // ������ ������ ��������� �� ���������� ��� �����
        SetButtonInactive();
        Debug.Log("������ ���������");
    }

    // ����� ��� ������� ������ ��������� � ����������
    public void SetButtonInactive()
    {
        buttonCanvasGroup.alpha = 0f; // ������ ����� �� 0, ��� ������ ���� ���������
        buttonCanvasGroup.interactable = false; // ������� ������ ����������
        buttonCanvasGroup.blocksRaycasts = false; // �� ��������� �������
        Debug.Log("������ ���������");
    }

    // ����� ��� ������� ������ ������� � ��������
    public void SetButtonActive()
    {
        buttonCanvasGroup.alpha = 1f; // ³��������� ��������
        buttonCanvasGroup.interactable = true; // ������ ������ ��������
        buttonCanvasGroup.blocksRaycasts = true; // ������� ������� � ������ ����������
        Debug.Log("������ �������");
    }

    // ���� ������� �������� ������ ���� ��������
    public void ShowButtonAfterDelay()
    {
        Debug.Log("��������� �������� ��� ������ ������");
        StartCoroutine(ShowButtonCoroutine());
    }

    private IEnumerator ShowButtonCoroutine()
    {
        Debug.Log("�������� ����������...");
        yield return new WaitForSeconds(0.1f); // ������ 0.1 �������
        SetButtonActive();
    }
}
