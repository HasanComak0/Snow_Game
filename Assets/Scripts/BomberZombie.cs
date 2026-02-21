using UnityEngine;

public class BomberZombie : MonoBehaviour
{
    public float Health = 20;
    public float speed = 2;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    public void TakeDamage(int hasar)
    {
        Health -= hasar;
        if (Health <= 0)
        {
            Explode();
            Debug.Log("Bomber Zombie Death");
            Destroy(gameObject);
        }
    }
    void Explode()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 3f);
        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject == this.gameObject)
                continue;

            if (hit.CompareTag("Zombie"))
            {
                hit.SendMessage("TakeDamage", 999, SendMessageOptions.DontRequireReceiver);
                Debug.Log("Patladý");
            }
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

