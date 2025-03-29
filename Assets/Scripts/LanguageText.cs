using UnityEngine;
using UnityEngine.UI;

public class LanguageText : MonoBehaviour
{
    public int language;
    public string[] text;
    private Text textLine;

    void Start()
    {
        language = PlayerPrefs.GetInt("language", language); //завантажити мову
        textLine = GetComponent<Text>(); //звертаємось до компоненту
        textLine.text = "" + text[language]; //вказуємо який текст буде відображено, в залежності обраної мови
    }
}