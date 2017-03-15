using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {



    UIManager UiManger;
    [Header("Setup")]
    public GameObject deathParticlesEffect;

    [Header("Enemy Attributes")]
    public float initSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float health = 100;
    public int bounty = 10;

    private bool isDead = false;

	// Use this for initialization
	void Start () {
        speed = initSpeed;
        UiManger = UIManager.instance;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0 && isDead == false)
        {        
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        PlayerStats.Money += bounty;
        UiManger.MoneyUi.text = PlayerStats.Money.ToString();

        GameObject deathEffect = (GameObject)Instantiate(deathParticlesEffect, transform.position, Quaternion.identity);
        Destroy(deathEffect, 2f);
        Destroy(gameObject);
        WaveSpawner.EnemiesAlive--;
    }

    public void Slow(float slowAmmount)
    {
        speed = initSpeed * (1f - slowAmmount);
    }

    public void ResetSpeed()
    {
        speed = initSpeed;
    }

    
}
