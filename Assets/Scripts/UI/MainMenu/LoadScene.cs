using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public void OnLoadScene(Object scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene.name);
    }
}