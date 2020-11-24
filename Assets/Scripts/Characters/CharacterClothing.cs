using UnityEngine;

public class CharacterClothing : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] private ProductsData _productsData;
    
    void Start()
    {
        if (_productsData.Product != null)
        {
            _skinnedMeshRenderer.sharedMesh = _productsData.Product; 
        }
    }
}