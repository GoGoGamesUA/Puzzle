using UnityEngine;
using System.Collections;

public class ButtonVisibilityControl : MonoBehaviour
{
    private CanvasGroup buttonCanvasGroup; // Посилання на CanvasGroup кнопки

    void Start()
    {
        // Отримуємо компонент CanvasGroup на самому об'єкті кнопки
        buttonCanvasGroup = GetComponent<CanvasGroup>();

        // Задаємо кнопку невидимою та неактивною при старті
        SetButtonInactive();
        Debug.Log("Кнопка прихована");
    }

    // Метод для зробити кнопку невидимою і неактивною
    public void SetButtonInactive()
    {
        buttonCanvasGroup.alpha = 0f; // Задаємо альфу на 0, щоб кнопка була невидимою
        buttonCanvasGroup.interactable = false; // Зробити кнопку неактивною
        buttonCanvasGroup.blocksRaycasts = false; // Не блокувати взаємодію
        Debug.Log("Кнопка прихована");
    }

    // Метод для зробити кнопку видимою і активною
    public void SetButtonActive()
    {
        buttonCanvasGroup.alpha = 1f; // Відновлюємо видимість
        buttonCanvasGroup.interactable = true; // Робимо кнопку активною
        buttonCanvasGroup.blocksRaycasts = true; // Блокуємо взаємодію з іншими елементами
        Debug.Log("Кнопка відкрита");
    }

    // Якщо потрібно показати кнопку після затримки
    public void ShowButtonAfterDelay()
    {
        Debug.Log("Викликаємо корутину для показу кнопки");
        StartCoroutine(ShowButtonCoroutine());
    }

    private IEnumerator ShowButtonCoroutine()
    {
        Debug.Log("Затримка починається...");
        yield return new WaitForSeconds(0.1f); // Чекаємо 0.1 секунди
        SetButtonActive();
    }
}
