using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void QuitGame()
    {
        // ��������, �� �� �� � �������� Unity
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
