using UnityEngine;

[CreateAssetMenu(fileName = "New Produc", menuName = "Product")]
public class ProductData : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private Mesh _mesh;

    public Sprite Icon => _icon;

    public Mesh Mesh => _mesh;
}