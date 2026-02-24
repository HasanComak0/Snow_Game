using TMPro;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public float health =100;
    public TextMeshProUGUI txt_health;
    public GameObject txt_gameOver;
    public GameObject HomeButton;
    public GameObject RestartButton;

    private bool isDead = false;

    private void Start()
    {
        txt_health.text = "Healht: " + health;
        Time.timeScale = 1f;
    }
    void Update()
    {
        if(health <= 0)
        {
            if (health < 0 && !isDead)
            {
                txt_health.text = "Health: 0";
                txt_gameOver.SetActive(true);
                HomeButton.SetActive(true);
                RestartButton.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
    public void reduceHealth(float h)//can düþürme
    {
        if (isDead) return;

        health -= h;
        txt_health.text = "Health: " + health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="nZombie")
        {
            reduceHealth(2);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "sZombie")
        {
            reduceHealth(5);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "bZombie")
        {
            reduceHealth(10);
            Destroy(collision.gameObject);
        }
    }
}
