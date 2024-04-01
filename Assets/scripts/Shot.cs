using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Shot : ClasePadre
{
    [SerializeField] GameObject Bullets;
    [SerializeField] float speed;
    [SerializeField] float strenght;
    [SerializeField] Transform spawnPoint;

    public override void Trigger(Vector3 direction)
    {
        print("pew");

        GameObject bulletInstance = GameObject.Instantiate
        (Bullets,
        spawnPoint.position,
        Quaternion.identity);

        LinearMovement linearMovementComponent = bulletInstance.GetComponent<LinearMovement>();
        linearMovementComponent.BulletSpeedAndDirection(speed, direction);

        Destroy(bulletInstance, 1f);
    }
}