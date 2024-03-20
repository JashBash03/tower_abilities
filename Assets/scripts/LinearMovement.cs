using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    
    Rigidbody2D rbBala;

    public void BulletSpeedAndDirection(float speed, Vector3 direction)
    {
        print(direction);
        rbBala = GetComponent<Rigidbody2D>();
        rbBala.velocity = direction * speed;
    }
}
