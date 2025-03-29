using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject[] puzzlePieces;
    public GameObject[] puzzlePiecesPanel2;
    public GameObject panelPuzzle1;
    public GameObject buttonNext;

    private Quaternion[] correctRotations;
    private CanvasGroup buttonCanvasGroup;
    private bool puzzleCompleted = false; // Для того, щоб уникнути повторного відкриття кнопки

    void Start()
    {
        correctRotations = new Quaternion[puzzlePieces.Length];
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            correctRotations[i] = puzzlePieces[i].transform.rotation;
            puzzlePieces[i].GetComponent<PuzzlePiece>().RandomizeRotation();
        }
        panelPuzzle1.SetActive(false);
        buttonNext.SetActive(false);

        // Перевіряємо, чи це потрібний об'єкт для запуску цієї логіки
        if (this.gameObject.name == "PanelPuzzle") // Замінити на ім'я об'єкта, на якому потрібен цей скрипт
        {
            Debug.Log("Start викликано!");

            // Перевірка наявності CanvasGroup на кнопці
            buttonCanvasGroup = buttonNext.GetComponent<CanvasGroup>();

            if (buttonCanvasGroup == null)
            {
                Debug.LogError("CanvasGroup не знайдений на кнопці!");
            }
            else
            {
                // Початкове приховування кнопки
                SetButtonInactive();
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    hit.collider.gameObject.GetComponent<PuzzlePiece>().RotatePiece();
                    CheckIfPuzzleComplete();
                }
            }
        }
    }

    public void CheckIfPuzzleComplete()
    {
        // Логіка перевірки, чи пазл зібраний
        bool isPuzzleComplete = true;

        float threshold = 0.01f; // Поріг точності для порівняння кватерніонів

        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            if (Quaternion.Angle(puzzlePieces[i].transform.rotation, correctRotations[i]) > threshold)
            {
                isPuzzleComplete = false;
                break;
            }
        }

        if (isPuzzleComplete && !puzzleCompleted)
        {
            puzzleCompleted = true; // Встановлюємо, що пазл зібраний
            Debug.Log("Пазл зібраний! Відкриваю кнопку.");
            OpenNextButton();
        }
    }

    // Метод для активації кнопки
    private void OpenNextButton()
    {
        if (buttonCanvasGroup != null)
        {
            buttonCanvasGroup.alpha = 1f; // Відновлюємо видимість
            buttonCanvasGroup.interactable = true; // Кнопка стає активною
            buttonCanvasGroup.blocksRaycasts = true; // Блокуємо взаємодію з іншими елементами
            Debug.Log("Кнопка активована!");
        }
    }

    // Метод для приховування кнопки
    private void SetButtonInactive()
    {
        if (buttonCanvasGroup != null)
        {
            buttonCanvasGroup.alpha = 0f; // Задаємо альфу на 0, щоб кнопка була невидимою
            buttonCanvasGroup.interactable = false; // Зробити кнопку неактивною
            buttonCanvasGroup.blocksRaycasts = false; // Не блокувати взаємодію
        }
    }

    // Метод для переходу до наступного пазлу
    public void OnNextPuzzle()
    {
        panelPuzzle1.SetActive(true);
        foreach (var piece in puzzlePiecesPanel2)
        {
            piece.GetComponent<PuzzlePiece>().RandomizeRotation();
        }
        buttonNext.SetActive(false);
    }
}
