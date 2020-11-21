using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public void OnLoadScene(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }
}