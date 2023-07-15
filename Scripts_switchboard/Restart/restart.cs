using UnityEngine.SceneManagement;
using UnityEngine;

public class restart : MonoBehaviour
{
    public void ReplayScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}