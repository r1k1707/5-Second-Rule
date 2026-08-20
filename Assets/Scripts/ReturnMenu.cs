using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenu : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void ReturnMenu1()
    {
        SceneManager.LoadScene(sceneName);
    }
}
