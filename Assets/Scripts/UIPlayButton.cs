using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPlayButton : MonoBehaviour
{
    [SerializeField] string levelName;

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelName);
    }
}
