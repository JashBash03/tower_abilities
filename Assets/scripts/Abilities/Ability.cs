using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability: ScriptableObject
{
    [SerializeField] string abilityName;

    public abstract void Trigger(Vector3 direction);

    public abstract void PlayerTransform(Transform player);
}
