using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int startingHealth;
    [SerializeField] int currentHealth;
    [SerializeField] Image healthIndicator;

    void Start()
    {
        currentHealth = startingHealth;
    }

    public void UpdateHealthImage()
    {
        healthIndicator.fillAmount = (1.0f * currentHealth / startingHealth);
    }

    public void Damage(int damage)
    {

        currentHealth -= damage;
        UpdateHealthImage();
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);

        if (currentHealth == 0)
        {
            GameEvents.PlayerDied.Invoke();
        }
    }
    public void Heal(int damage)
    {
        currentHealth += damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);
    }
}