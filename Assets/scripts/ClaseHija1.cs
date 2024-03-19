using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Hija1 : ClasePadre
{
    [SerializeField] GameObject Bullets;
    [SerializeField] float speed;
    [SerializeField] float strenght;
    [SerializeField] Transform spawnPoint;


    public override void Trigger()
    {
        print("pew");

        Vector3 globalMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        globalMousePos.z = 0f;
        Vector3 aiming = (globalMousePos - spawnPoint.position).normalized;

        GameObject bulletInstance = GameObject.Instantiate
        (Bullets,
        spawnPoint.position,
        Quaternion.identity);

        Rigidbody2D rbBala = bulletInstance.GetComponent<Rigidbody2D>();

        if (Bullets != null)
        {
            rbBala.velocity = aiming * speed;
        }
        Destroy(bulletInstance, 1f);
    }
}