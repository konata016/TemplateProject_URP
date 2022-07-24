using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
    public abstract bool IsMoving { get; protected set; } 

    public abstract void Initialize();

    public abstract void OnEnter(
        float movingSpeed,
        Vector3 position,
        Quaternion rotation);

    public abstract void OnUpdate();

    public abstract void OnExit();
}
