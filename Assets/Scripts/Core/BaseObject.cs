﻿using UnityEngine;

namespace Parallax.Base
{
    [DisallowMultipleComponent]
    public class BaseObject : MonoBehaviour
    {
        public virtual void BaseObjectAwake() { }

        public virtual void BaseObjectStart() { }

        public virtual void BaseObjectUpdate() { }

        public virtual void BaseObjectFixedUpdate() { }

        public virtual void BaseObjectLateUpdate() { }

        public virtual void BaseObjectOnDestroy() { }
    }
}
