using UnityEngine;

public class ProductList : MonoBehaviour
{
    [SerializeField] private ProductButton _productButton;
    [SerializeField] private UnityEngine.UI.GridLayoutGroup _gridLayoutGroup;
    [SerializeField] private SkinnedMeshRenderer _characterMesh;
    [SerializeField] private ProductData[] _products;
    [SerializeField] private ProductsData _productsData;

    private void Start()
    {
        Fill();
    }

    private void Fill()
    {
        foreach (var product in _products)
        {
            ProductButton newProductButton = Instantiate(_productButton);
            newProductButton.Init(product, _characterMesh, _productsData);
            newProductButton.transform.SetParent(_gridLayoutGroup.transform);
            newProductButton.transform.localScale = Vector3.one;
            newProductButton.GetComponent<RectTransform>().localPosition = Vector3.zero;
        }
    }
}