using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CurrencyManager : MonoBehaviour
{
    public Text silverCoinText;
    public Text goldCoinText;
    public Slider volumeSlider;

    public int language;

    private int silverCoins;
    private int goldCoins;

    void Start()
    {
        language = PlayerPrefs.GetInt("language", language);

        // Завантажуємо збережені монети
        silverCoins = PlayerPrefs.GetInt("SilverCoins", 0);
        goldCoins = PlayerPrefs.GetInt("GoldCoins", 0);

        // Оновлюємо текстові поля
        UpdateCurrencyText();

        // Завантажуємо збережену гучність
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);

        // Підписуємось на зміну значення слайдера
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // Оновлюємо текстові поля для монет
    public void UpdateCurrencyText()
    {
        silverCoinText.text = silverCoins.ToString();
        goldCoinText.text = goldCoins.ToString();
    }

    // Метод для збільшення кількості срібних монет
    public void AddSilverCoins(int amount)
    {
        silverCoins += amount;
        PlayerPrefs.SetInt("SilverCoins", silverCoins);
        PlayerPrefs.Save();  // Зберігаємо зміни
        UpdateCurrencyText();
    }

    // Метод для збільшення кількості золотих монет
    public void AddGoldCoins(int amount)
    {
        goldCoins += amount;
        PlayerPrefs.SetInt("GoldCoins", goldCoins);
        PlayerPrefs.Save();  // Зберігаємо зміни
        UpdateCurrencyText();
    }

    // Метод для зміни гучності
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);  // Зберігаємо гучність
        PlayerPrefs.Save();  // Зберігаємо зміни
    }

    //Локалізація
    public void EnglishLanguage()
    {
        language = 0;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene("MainMenu");
    }

    public void UkraineLanguage()
    {
        language = 1;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene("MainMenu");
    }

    public void PolandLanguage()
    {
        language = 2;
        PlayerPrefs.SetInt("language", language);
        SceneManager.LoadScene("MainMenu");
    }
}
