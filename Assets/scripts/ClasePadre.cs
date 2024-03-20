using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClasePadre : MonoBehaviour
{
    [SerializeField] string abilityName;
    [SerializeField] float colldown;

    public abstract void Trigger(Vector3 direction);
}
