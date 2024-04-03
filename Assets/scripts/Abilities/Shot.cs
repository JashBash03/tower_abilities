using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Shot : ClasePadre
{
    [SerializeField] GameObject Bullets;
    [SerializeField] float speed;
    [SerializeField] List<Transform> Spawn;
    [SerializeField] Transform spawnPoint;

    public override void Trigger(Vector3 direction)
    {
        for (int i = 0; i < Spawn.Count; i++)
        {
            GameObject projectileInstance = Instantiate(
                Bullets,
                Spawn[i].position,
                Quaternion.identity
            );
            LinearMovement linearMovementComponent = projectileInstance.GetComponent<LinearMovement>();
            linearMovementComponent.SetSpeedAndDirection(speed, direction);
            Destroy(projectileInstance, 0.9f);
        }
    }
}