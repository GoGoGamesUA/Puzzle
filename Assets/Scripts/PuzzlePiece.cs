using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public Vector3 correctPosition; // �� ���� ��������� ���� ��� ����� �������� (���� �������)
    public float correctRotation = 0f; // ������ ���������� ��� ��������� (���������, 0, 90, 180, 270)

    void Start()
    {
        // ���� �������, ����� ������������ ��������� ��������� ��� ������� ��������
        correctRotation = transform.eulerAngles.z; // ��� 0, ���� �� ������ �������� ������� �� �������� �� 0 �������
    }

    public void RotatePiece()
    {
        // ������� �� 90 �������
        transform.Rotate(0, 0, 90);
    }

    // ����� ��� ��������, �� �������� �������� ���������
    public bool IsCorrectRotation()
    {
        float currentRotation = transform.eulerAngles.z;

        // ��������, �� ��������� � 0, 90, 180, ��� 270
        return (Mathf.Approximately(currentRotation % 360, correctRotation) || Mathf.Approximately(currentRotation % 360, correctRotation + 90));
    }

    // ����������� ������ (����� ������ �� �����)
    public void RandomizeRotation()
    {
        float randomRotation = Random.Range(0, 4) * 90; // �������� ������� 0, 90, 180 ��� 270 �������
        transform.Rotate(0, 0, randomRotation);
    }
}
