using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public bool isInvincible;
    public SpriteRenderer spriteRenderer;
    public float WaitFlash = 0.2f;
    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }

   
    void Update()
    {

        healthBar.Sethealth(currentHealth);

        if (currentHealth <= 0)
            Destroy(gameObject);
        
    }

    public void TakeDamage(int damage)
    {
        if(!isInvincible)
        {
            currentHealth -= damage;
            healthBar.Sethealth(currentHealth);
            isInvincible = true;
            StartCoroutine( InvinciblityFlash());
            StartCoroutine(InvincibleWait());
        }
    }

    public IEnumerator InvinciblityFlash()
    {
        while(isInvincible)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(WaitFlash);

            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(WaitFlash);
        }
       
    }
    public IEnumerator InvincibleWait()
    {
        yield return new WaitForSeconds(2f);
        isInvincible = false;

    }
}
