using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common
{
    public class SceneLoader : MonoBehaviour
    {
        public void ReloadScene()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
