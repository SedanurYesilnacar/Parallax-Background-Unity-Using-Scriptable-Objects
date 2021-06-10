using UnityEngine;

using Parallax.Base;
using Parallax.Management;

public class LayerController : BaseObject
{
    [SerializeField] private Layer layer = default;
    [SerializeField] private int _orderInLayer;
    [SerializeField] private Vector2 _speed;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Vector2 _spriteSize = new Vector2(100, 10.8f);

    [SerializeField] private bool _infiniteHorizontal = true;
    [SerializeField] private bool _infiniteVertical = false;
    [SerializeField] private bool _autoMoving = false;

    SpriteRenderer spriteRenderer;

    Transform cameraTransform;
    Vector3 cameraLastPosition;

    private float _textureUnitSizeX;
    private float _textureUnitSizeY;

    private GameManager instance;


    public override void BaseObjectStart()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        _orderInLayer = layer.orderInLayer;
        _speed = layer.speed;
        _sprite = layer.sprite;

        spriteRenderer.sprite = _sprite;
        spriteRenderer.size = _spriteSize;
        spriteRenderer.sortingOrder = _orderInLayer;

        cameraTransform = Camera.main.transform;
        cameraLastPosition = cameraTransform.position;

        Texture2D texture = _sprite.texture;
        _textureUnitSizeX = texture.width / _sprite.pixelsPerUnit;
        _textureUnitSizeY = texture.height / _sprite.pixelsPerUnit;

    }

    public override void BaseObjectLateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - cameraLastPosition;
        transform.position += new Vector3(- deltaMovement.x * _speed.x, - deltaMovement.y * _speed.y, deltaMovement.z);
        cameraLastPosition = cameraTransform.position;

        if(_infiniteHorizontal)
        {
            if(Mathf.Abs(cameraTransform.position.x - transform.position.x) >= _textureUnitSizeX)
            {
                float offsetX = (cameraTransform.position.x - transform.position.x) % _textureUnitSizeX;
                transform.position = new Vector3(cameraTransform.position.x + offsetX, transform.position.y, transform.position.z);
            }
        }

        if(_infiniteVertical)
        {
            if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= _textureUnitSizeY)
            {
                float offsetY = (cameraTransform.position.y - transform.position.y) % _textureUnitSizeY;
                transform.position = new Vector3(cameraTransform.position.x, transform.position.y + offsetY, transform.position.z);
            }
        }

        if (_autoMoving)
        {
            transform.position -= new Vector3(_speed.x * Time.fixedDeltaTime, 0, 0);
        }
    }
}
