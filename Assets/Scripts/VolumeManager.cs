using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider volumeSlider;  // Слайдер для гучності

    void Start()
    {
        // Якщо у нас є збережене значення гучності, встановлюємо його
        volumeSlider.value = AudioListener.volume;

        // Підписуємось на зміну значення слайдера
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // Метод для зміни гучності
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;  // Зміна гучності
    }
}
