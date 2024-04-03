using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

[CreateAssetMenu(fileName = "Shot", menuName = "Abilities/Shot")]
public class Shot : Ability
{
    [SerializeField] GameObject Bullets;
    [SerializeField] float speed;
    [SerializeField] Transform Spawn;


    public override void PlayerTransform(Transform player)
    {
        Transform bulletSpawn = player.Find("BulletSpawn");
    }
    public override void Trigger(Vector3 direction)
    {
        GameObject projectileInstance = Instantiate(
            Bullets,
            Spawn.position,
            Quaternion.identity
        );
        LinearMovement linearMovementComponent = projectileInstance.GetComponent<LinearMovement>();
        linearMovementComponent.SetSpeedAndDirection(speed, direction);
        Destroy(projectileInstance, 0.9f);
    }
}