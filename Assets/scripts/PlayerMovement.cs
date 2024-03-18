using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Update()
    {
        Vector3 positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        positionMouse.z = transform.position.z;
        Vector3 directionToMouse = (positionMouse - transform.position).normalized;
        transform.up = directionToMouse;
    }
}