using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float hiz = 2;
    public GameObject player;
    void Update()
    {
        transform.Translate(-Vector2.up * hiz * Time.deltaTime);
    }
}
