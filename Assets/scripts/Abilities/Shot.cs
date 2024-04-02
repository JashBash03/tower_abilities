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
            GameObject bulletInstance = GameObject.Instantiate
            (Bullets,
            Spawn[i].position,
            Quaternion.identity
            );
            LinearMovement lm = bulletInstance.GetComponent<LinearMovement>();
            lm.bulletShoot(direction, speed);
            Destroy(bulletInstance, 1f);

            lm.Shoot(direction);

        }
    }
}