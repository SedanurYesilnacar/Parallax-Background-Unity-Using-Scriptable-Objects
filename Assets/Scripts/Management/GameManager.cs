using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Parallax.Base;
using Parallax.Extensions;
using Parallax.Singleton;

namespace Parallax.Management
{
    [DisallowMultipleComponent]
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private List<BaseObject> baseObjects;

        private void Awake()
        {
            baseObjects = new List<BaseObject>(FindObjectsOfType<BaseObject>());
            CallAwakes();
        }

        private void Start()
        {
            CallStarts();
        }

        private void Update()
        {
            CallUpdates();
        }

        private void FixedUpdate()
        {
            CallFixedUpdates();
        }

        private void LateUpdate()
        {
            CallLateUpdates();
        }

        private void OnDestroy()
        {
            CallOnDestroys();
        }

        private void CallAwakes()
        {
            baseObjects.Call(x => x.BaseObjectAwake());
        }

        private void CallStarts()
        {
            baseObjects.Call(x => x.BaseObjectStart());
        }

        private void CallUpdates()
        {
            baseObjects.Call(x => x.BaseObjectUpdate());
        }

        private void CallFixedUpdates()
        {
            baseObjects.Call(x => x.BaseObjectFixedUpdate());
        }

        private void CallLateUpdates()
        {
            baseObjects.Call(x => x.BaseObjectLateUpdate());
        }

        private void CallOnDestroys()
        {
            baseObjects.Call(x => x.BaseObjectOnDestroy());
        }
    }
}