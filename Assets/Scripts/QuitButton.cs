using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void QuitGame()
    {
        // Перевірка, чи це не в редакторі Unity
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
