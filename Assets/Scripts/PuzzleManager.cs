using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public GameObject[] puzzlePieces;
    public GameObject[] puzzlePiecesPanel2;
    public GameObject panelPuzzle1;
    public GameObject buttonNext;

    private Quaternion[] correctRotations;
    private CanvasGroup buttonCanvasGroup;
    private bool puzzleCompleted = false; // ��� ����, ��� �������� ���������� �������� ������

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

        // ����������, �� �� �������� ��'��� ��� ������� ���� �����
        if (this.gameObject.name == "PanelPuzzle") // ������� �� ��'� ��'����, �� ����� ������� ��� ������
        {
            Debug.Log("Start ���������!");

            // �������� �������� CanvasGroup �� ������
            buttonCanvasGroup = buttonNext.GetComponent<CanvasGroup>();

            if (buttonCanvasGroup == null)
            {
                Debug.LogError("CanvasGroup �� ��������� �� ������!");
            }
            else
            {
                // ��������� ������������ ������
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
        // ����� ��������, �� ���� �������
        bool isPuzzleComplete = true;

        float threshold = 0.01f; // ���� ������� ��� ��������� ����������

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
            puzzleCompleted = true; // ������������, �� ���� �������
            Debug.Log("���� �������! ³������� ������.");
            OpenNextButton();
        }
    }

    // ����� ��� ��������� ������
    private void OpenNextButton()
    {
        if (buttonCanvasGroup != null)
        {
            buttonCanvasGroup.alpha = 1f; // ³��������� ��������
            buttonCanvasGroup.interactable = true; // ������ ��� ��������
            buttonCanvasGroup.blocksRaycasts = true; // ������� ������� � ������ ����������
            Debug.Log("������ ����������!");
        }
    }

    // ����� ��� ������������ ������
    private void SetButtonInactive()
    {
        if (buttonCanvasGroup != null)
        {
            buttonCanvasGroup.alpha = 0f; // ������ ����� �� 0, ��� ������ ���� ���������
            buttonCanvasGroup.interactable = false; // ������� ������ ����������
            buttonCanvasGroup.blocksRaycasts = false; // �� ��������� �������
        }
    }

    // ����� ��� �������� �� ���������� �����
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
