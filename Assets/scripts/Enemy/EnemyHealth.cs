using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    int currentHealth = 10;
    int startingHealth = 10;
    [SerializeField] Image health;

    private void Start()
    {
        currentHealth = startingHealth;
    }
    public void Hurt(float amount)
    {
        currentHealth -= (int)amount;
        UpdateHealthImage();
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            print("Enemigo muerto, abondo pa mi huerto");
        }
    }

    void UpdateHealthImage()
    {
        health.fillAmount = (1.0f * currentHealth / startingHealth);
    }
}