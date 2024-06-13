using Scellecs.Morpeh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

public struct MovingComponent : IComponent
{
    public Transform transform;
    public float moveSpeed;
}
