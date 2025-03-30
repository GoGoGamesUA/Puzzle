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

        // ����������� �������� ������
        silverCoins = PlayerPrefs.GetInt("SilverCoins", 0);
        goldCoins = PlayerPrefs.GetInt("GoldCoins", 0);

        // ��������� ������� ����
        UpdateCurrencyText();

        // ����������� ��������� �������
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);

        // ϳ��������� �� ���� �������� ��������
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // ��������� ������� ���� ��� �����
    public void UpdateCurrencyText()
    {
        silverCoinText.text = silverCoins.ToString();
        goldCoinText.text = goldCoins.ToString();
    }

    // ����� ��� ��������� ������� ������ �����
    public void AddSilverCoins(int amount)
    {
        silverCoins += amount;
        PlayerPrefs.SetInt("SilverCoins", silverCoins);
        PlayerPrefs.Save();  // �������� ����
        UpdateCurrencyText();
    }

    // ����� ��� ��������� ������� ������� �����
    public void AddGoldCoins(int amount)
    {
        goldCoins += amount;
        PlayerPrefs.SetInt("GoldCoins", goldCoins);
        PlayerPrefs.Save();  // �������� ����
        UpdateCurrencyText();
    }

    // ����� ��� ���� �������
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);  // �������� �������
        PlayerPrefs.Save();  // �������� ����
    }

    //����������
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
