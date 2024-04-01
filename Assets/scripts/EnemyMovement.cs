using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Transform playerTransform;
    [SerializeField] int enemyDamage = 1;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {

        Vector3 enemyToPlayer = (playerTransform.position - transform.position).normalized;

        transform.position += enemyToPlayer * speed * Time.deltaTime;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.Damage(enemyDamage);

            Destroy(gameObject);
        }
    }
}
