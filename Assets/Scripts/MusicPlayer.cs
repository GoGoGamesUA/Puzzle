using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] musicClips;  // Массив для трьох мелодій
    private AudioSource audioSource;
    private int currentTrackIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayNextTrack();
    }

    void Update()
    {
        // Якщо поточна мелодія закінчилась, переходимо до наступної
        if (!audioSource.isPlaying)
        {
            PlayNextTrack();
        }
    }

    void PlayNextTrack()
    {
        audioSource.clip = musicClips[currentTrackIndex];  // Встановлюємо поточну мелодію
        audioSource.Play();  // Відтворюємо

        // Оновлюємо індекс для наступної мелодії
        currentTrackIndex++;

        // Якщо індекс перевищує кількість треків, починаємо знову з першого
        if (currentTrackIndex >= musicClips.Length)
        {
            currentTrackIndex = 0;
        }
    }
}
