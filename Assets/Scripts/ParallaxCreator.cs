using UnityEngine;
using Parallax.Base;

public class ParallaxCreator : BaseObject
{
    [SerializeField] private int _layerCount;
    [SerializeField] private GameObject _layerGO;

    public override void BaseObjectStart()
    {
        CreateBackground();
    }

    private void CreateBackground()
    {
        for(int i = 0; i < _layerCount; i++)
        {
            Instantiate(_layerGO, _layerGO.transform.position, Quaternion.identity);
        }
    }
}
