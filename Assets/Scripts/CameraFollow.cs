using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Parallax.Base;

public class CameraFollow : BaseObject
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothFactor = 10f;

    public override void BaseObjectLateUpdate()
    {
        Vector3 desiredPos = _target.position + _offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, _smoothFactor * Time.deltaTime);
        transform.position = smoothedPos;
    }
}
