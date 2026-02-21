using UnityEngine;

public class NormalZombie : MonoBehaviour
{
    public float Health = 10;
    public float speed = 2;
    
    void Update()
    {
        transform.Translate (Vector2.left*speed*Time.deltaTime);    
    }
    public void TakeDamage(int hasar)
    {
        Health -= hasar;
        if (Health <= 0)
        {
            Debug.Log("Normal Zombie Death");
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            TakeDamage(10);        
        }
    }
}
