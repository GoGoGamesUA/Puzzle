using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] musicClips;  // ������ ��� ����� ������
    private AudioSource audioSource;
    private int currentTrackIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayNextTrack();
    }

    void Update()
    {
        // ���� ������� ������ ����������, ���������� �� ��������
        if (!audioSource.isPlaying)
        {
            PlayNextTrack();
        }
    }

    void PlayNextTrack()
    {
        audioSource.clip = musicClips[currentTrackIndex];  // ������������ ������� ������
        audioSource.Play();  // ³���������

        // ��������� ������ ��� �������� ����䳿
        currentTrackIndex++;

        // ���� ������ �������� ������� �����, �������� ����� � �������
        if (currentTrackIndex >= musicClips.Length)
        {
            currentTrackIndex = 0;
        }
    }
}
