using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] public int damage;
    Transform playerTransform;
    bool death = false;

    void RandomEnemy()
    {
        transform.position = new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), 0);
    }
    void Start()
    {
        GameEvents.PlayerDied.AddListener(OnPlayerDeath);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void OnPlayerDeath()
    {
        death = true;
    }

    void Spawn2()
    {
        GameEvents.EnemySpawn.Invoke();
        GameEvents.EnemySpawn.Invoke();
    }
    void Update()
    {
        Vector3 directionToPlayer = Vector3.zero;

        directionToPlayer = playerTransform.position - transform.position;

        directionToPlayer = directionToPlayer.normalized;

        if (death)
        {
            transform.position -= directionToPlayer * speed * Time.deltaTime;
        }
        else
        {
            transform.position += directionToPlayer * speed * Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.Hurt(damage);
            Spawn2();
            GameObject.Destroy(gameObject);
        }
    }
}
