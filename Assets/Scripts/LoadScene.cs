public class LoadScene : UnityEngine.MonoBehaviour
{
    public void OnLoad(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }
}