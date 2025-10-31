using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthbar;
    public int health = 100;
    public GameObject DeathUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DeathUI.SetActive(false);
        healthbar.value = health;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if ((health -= damage) <= 0)
        {
            health = 0;
            healthbar.value = health;
            DeathUI.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            health -= damage;
            healthbar.value = health;
        }
    }
}
