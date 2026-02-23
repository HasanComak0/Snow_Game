using UnityEngine;

public class ShieldZombie : MonoBehaviour
{
    public float Health = 30;
    public float speed = 2;

    public bool isDead = false;
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int hasar)
    {
        if (isDead) return;

        Health -= hasar;
        if (Health <= 0)
        {
            isDead = true;

            bulletSpawn bs = FindAnyObjectByType<bulletSpawn>();
            if (bs != null) 
            {
                bs.AddXp(5);
            }

            Debug.Log("Shield Zombie Death");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            TakeDamage(10);

        }
    }
}
