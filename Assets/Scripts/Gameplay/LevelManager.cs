using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

public class LevelManager : Singleton<LevelManager>
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
