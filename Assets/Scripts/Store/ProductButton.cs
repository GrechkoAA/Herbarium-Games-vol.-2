using UnityEngine;

public class ProductButton : MonoBehaviour
{
    private Sprite _icon;
    private Mesh _mesh;
    private SkinnedMeshRenderer _characterMesh;
    private ProductsData _productsData;

    public void Init(ProductData product, SkinnedMeshRenderer characterMesh, ProductsData productsData)
    {
        _icon = product.Icon;
        _mesh = product.Mesh;
        _characterMesh = characterMesh;

        GetComponent<UnityEngine.UI.Image>().sprite = _icon;
        _productsData = productsData;
    }

    public void OnPut()
    {
        _characterMesh.sharedMesh = _mesh;
        _productsData.Product = _mesh;
    }
}
