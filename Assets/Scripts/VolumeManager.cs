using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider volumeSlider;  // ������� ��� �������

    void Start()
    {
        // ���� � ��� � ��������� �������� �������, ������������ ����
        volumeSlider.value = AudioListener.volume;

        // ϳ��������� �� ���� �������� ��������
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // ����� ��� ���� �������
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;  // ���� �������
    }
}
