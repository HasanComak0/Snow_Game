using UnityEngine;

public class BomberZombie : MonoBehaviour
{
    public float Health = 20;
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
                bs.AddXp(10);
            }

            Explode();
            Debug.Log("Bomber Zombie Death");
            Destroy(gameObject);
        }
    }
    void Explode()
    {
        if(isDead) return;
        isDead = true;

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 3f);
        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject == this.gameObject)
                continue;

            if (hit.CompareTag("nZombie"))
            {
                hit.SendMessage("TakeDamage", 999, SendMessageOptions.DontRequireReceiver);
                Debug.Log("Patladý");
            }
            if (hit.CompareTag("sZombie"))
            {
                hit.SendMessage("TakeDamage", 999, SendMessageOptions.DontRequireReceiver);
                Debug.Log("Patladý");
            }
            if (hit.CompareTag("bZombie"))
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

