using UnityEngine;

[CreateAssetMenu(fileName = "New Layer", menuName = "Parallax Background", order = 1)]
[RequireComponent(typeof(SpriteRenderer))]
public class Layer : ScriptableObject
{
    public int orderInLayer;
    public Vector2 speed;
    public Sprite sprite;

}
