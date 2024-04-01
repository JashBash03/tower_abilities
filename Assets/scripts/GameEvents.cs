using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public static UnityEvent PlayerDied = new UnityEvent();
    public static UnityEvent EnemySpawn = new UnityEvent();
}
