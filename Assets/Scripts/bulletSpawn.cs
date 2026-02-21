using UnityEngine;
using UnityEngine.SocialPlatforms;

public class bulletSpawn : MonoBehaviour
{
    public float timer=0;
    public GameObject bullet;
    public GameObject newBullet;
    public Transform playerTransform;
    [Range(0f, 5f)]
    public float maxTimer = 1;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > maxTimer)
        {
            newBullet = Instantiate(bullet);
            newBullet.transform.position =  playerTransform.position;
            Destroy(newBullet,3);
            timer = 0;
        }
    }
   
}
