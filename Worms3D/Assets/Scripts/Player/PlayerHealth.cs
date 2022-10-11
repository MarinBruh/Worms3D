using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    //public Slider healthSlider;
    //public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    PlayerController playerController;
    //private bool damaged;
    public bool isDead;
    public int currentHealth;

    public int CurrentHealth { get { return currentHealth; } }

    void Awake ()
    {
        playerController = GetComponent <PlayerController> ();
        currentHealth = startingHealth;
    }
    
    public void TakeDamage (int amount)
    {
        //damaged = true;

        currentHealth -= amount;

        //healthSlider.value = currentHealth;

        if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        playerController.enabled = false;
        this.gameObject.SetActive(false);
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
