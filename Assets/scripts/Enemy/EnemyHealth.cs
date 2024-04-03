using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 10;
    int currentHealth;
    [HideInInspector] public bool gameOver = false;
    [SerializeField] SpriteRenderer health;

    Color fullHealthColor = Color.green;
    Color zeroHealthColor = Color.red;

    void Start()
    {
        currentHealth = startingHealth;
        UpdateHealthColor();
    }

    void UpdateHealthColor()
    {
        float healthPercentage = (float)currentHealth / startingHealth;
        health.color = Color.Lerp(zeroHealthColor, fullHealthColor, healthPercentage);
    }
    public void Damage(float amount)
    {
        currentHealth -= (int)amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);
        
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            print("Enemigo muerto");
        }

        UpdateHealthColor();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            LinearMovement bullet = other.GetComponent<LinearMovement>();
            if (bullet != null)
            {
                Damage(2);
                Destroy(other.gameObject);
            }
        }
        if (other.CompareTag("BigBullet"))
        {
            LinearMovement bullet = other.GetComponent<LinearMovement>();
            if (bullet != null)
            {
                Damage(5);
                Destroy(other.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Damage(2);
                Destroy(gameObject);
            }
        }
    }
}