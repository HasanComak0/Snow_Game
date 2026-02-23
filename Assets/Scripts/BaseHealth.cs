using TMPro;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public float health =100;
    public TextMeshProUGUI txt_health;
    public GameObject txt_gameOver;

    private void Start()
    {
        txt_health.text = "Healht: " + health;
    }
    void Update()
    {
        if(health <= 0)
        {
            txt_health.text = "Health: 0";
            txt_gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void reduceHealth(float h)//can düþürme
    {
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
