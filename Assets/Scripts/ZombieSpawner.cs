using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject normalZombiePrefab;
    public GameObject bomberZombiePrefab;
    public GameObject ShieldZombiePrefab;

    public float timer = 0;
    public float maxTimer = 2;
    void Update()
    {
        timer += Time.deltaTime;
        if( timer > maxTimer )
        {
            int r = Random.Range(0, 3);//0 dahil 3 dahil deðil

            switch (r)
            {
                case 0:
                    Instantiate(normalZombiePrefab);
                    break;
                case 1:
                    Instantiate(bomberZombiePrefab);
                    break;
                case 2:
                    Instantiate(ShieldZombiePrefab);
                    break;
            }
            timer = 0;
        }
        
    }
}
