using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Transform playerTransform;
    [SerializeField] int enemyDamage;
    bool playerIsDead = false;
    bool enemyIsDead = false;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        GameEvents.PlayerDied.AddListener(OnPlayerDeath);
        GameEvents.EnemyDied.AddListener(OnEnemyDeath);
    }
    void OnPlayerDeath()
    {
        playerIsDead = true;
    }

    void OnEnemyDeath()
    {
        enemyIsDead = true;
    }
    void Update()
    {
        Vector3 enemyToPlayer = (playerTransform.position - transform.position).normalized;

        transform.position += enemyToPlayer * speed * Time.deltaTime;

        if (playerIsDead)
        {
            transform.position -= enemyToPlayer * speed * Time.deltaTime;
        }
        else
        {
            transform.position += enemyToPlayer * speed * Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Damage(enemyDamage);

                Vector3 directionToPlayer = playerTransform.position - transform.position;
                transform.position -= directionToPlayer * speed * Time.deltaTime;

                Destroy(gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            EnemyHealth enemyHealth = GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.Damage(enemyDamage);

                Vector3 directionToPlayer = playerTransform.position - transform.position;
                transform.position -= directionToPlayer * speed * Time.deltaTime;
            }
        }

        if (collision.gameObject.CompareTag("BigBullet"))
        {
            EnemyHealth enemyHealth = GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.Damage(enemyDamage);

                Vector3 directionToPlayer = playerTransform.position - transform.position;
                transform.position -= directionToPlayer * speed * Time.deltaTime;
            }
        }
    }
}