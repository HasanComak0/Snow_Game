using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject normalZombiePrefab;
    public GameObject bomberZombiePrefab;
    public GameObject ShieldZombiePrefab;

    public float timer = 0;
    public float maxTimer = 20;
    public float minTimer = 2;

    int sayac = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > maxTimer)
        {
            int r = Random.Range(0, 3);//0 dahil 3 dahil deðil

            switch (r)
            {
                case 0:
                    Instantiate(normalZombiePrefab, transform.position, transform.rotation);
                    break;
                case 1:
                    Instantiate(bomberZombiePrefab, transform.position, transform.rotation);
                    break;
                case 2:
                    Instantiate(ShieldZombiePrefab, transform.position, transform.rotation);
                    break;
            }
            timer = 0;
            sayac++;
        }
        if(sayac >10)
        {
            maxTimer -= 0.1f;
        }
        if (maxTimer <= minTimer) 
        {
            maxTimer = 2f;
        }

    }
}
