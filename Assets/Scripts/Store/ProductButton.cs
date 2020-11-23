using UnityEngine;

public class ProductButton : MonoBehaviour
{
    private Sprite _icon;
    private Mesh _mesh;

    private SkinnedMeshRenderer _characterMesh;

    public void Init(Sprite icon, Mesh mesh, SkinnedMeshRenderer characterMesh)
    {
        _icon = icon;
        _mesh = mesh;
        _characterMesh = characterMesh;

        GetComponent<UnityEngine.UI.Image>().sprite = _icon;
    }

    public void OnPut()
    {
        _characterMesh.sharedMesh = _mesh;
    }
}
