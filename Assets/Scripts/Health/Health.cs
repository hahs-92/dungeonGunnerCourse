using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthEvent))]
[DisallowMultipleComponent]
public class Health : MonoBehaviour
{
    private int startingHealth;
    private int currentHealth;
    private HealthEvent healthEvent;
    private Player player;

    [HideInInspector] public bool isDamageable = true;
    [HideInInspector] public Enemy enemy;

    private void Awake()
    {
        //Load compnents
        healthEvent = GetComponent<HealthEvent>();
    }

    private void Start()
    {
        // Trigger a health event for UI update
        CallHealthEvent(0);

        // Attempt to load enemy / player components
        player = GetComponent<Player>();
        enemy = GetComponent<Enemy>();
    }

    /// <summary>
    /// Public method called when damage is taken
    /// </summary>
    public void TakeDamage(int damageAmount)
    {
        bool isRolling = false;

        if (player != null)
            isRolling = player.playerControl.isPlayerRolling;

        if (isDamageable && !isRolling)
        {
            currentHealth -= damageAmount;
            CallHealthEvent(damageAmount);
        }


        if (isDamageable && isRolling)
        {
            Debug.Log("Dodged Bullet By Rolling");
        }
    }

    private void CallHealthEvent(int damageAmount)
    {
        // Trigger health event
        healthEvent.CallHealthChangedEvent(((float)currentHealth / (float)startingHealth), currentHealth, damageAmount);
    }

    /// <summary>
    /// Set starting health 
    /// </summary>
    public void SetStartingHealth(int startingHealth)
    {
        this.startingHealth = startingHealth;
        currentHealth = startingHealth;
    }

    /// <summary>
    /// Get the starting health
    /// </summary>
    public int GetStartingHealth()
    {
        return startingHealth;
    }

}
