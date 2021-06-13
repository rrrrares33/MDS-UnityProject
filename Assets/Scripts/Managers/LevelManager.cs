using UnityEngine.SceneManagement;
using Utils;

namespace Managers
{
    public class LevelManager : Singleton<LevelManager>
    {
        public static void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
