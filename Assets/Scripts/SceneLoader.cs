public class SceneLoader : UnityEngine.MonoBehaviour
{
    public void OnLoad(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }
}