using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public Vector3 correctPosition; // Це буде правильне місце для цього шматочка (якщо потрібно)
    public float correctRotation = 0f; // Задаємо правильний кут обертання (наприклад, 0, 90, 180, 270)

    void Start()
    {
        // Якщо потрібно, можна ініціалізувати правильне обертання для кожного шматочка
        correctRotation = transform.eulerAngles.z; // або 0, якщо ми хочемо спочатку зробити всі шматочки на 0 градусів
    }

    public void RotatePiece()
    {
        // Ротація на 90 градусів
        transform.Rotate(0, 0, 90);
    }

    // Метод для перевірки, чи шматочок обернуто правильно
    public bool IsCorrectRotation()
    {
        float currentRotation = transform.eulerAngles.z;

        // Перевірка, чи обертання є 0, 90, 180, або 270
        return (Mathf.Approximately(currentRotation % 360, correctRotation) || Mathf.Approximately(currentRotation % 360, correctRotation + 90));
    }

    // Рандомізація обертів (можна додати до класу)
    public void RandomizeRotation()
    {
        float randomRotation = Random.Range(0, 4) * 90; // Рандомно обираємо 0, 90, 180 або 270 градусів
        transform.Rotate(0, 0, randomRotation);
    }
}
