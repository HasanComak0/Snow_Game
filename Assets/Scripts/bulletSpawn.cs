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
    public float minTimer = 0.1f;

    public float currentXP = 0;
    public float xpLevel = 100;
    public float sonrakiLevelEsigi = 100;

    public GameObject xpAffect;
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

    public void AddXp(float xp)
    {
        currentXP += xp;

        if (currentXP >= sonrakiLevelEsigi)
        {
            Debug.Log("Level Up!!!!!!! Mevcut Xp: " + currentXP);
            sonrakiLevelEsigi += xpLevel;
            xpLevel = xpLevel * 1.5f;

            maxTimer -= 0.03f;
            if(maxTimer < minTimer)
                maxTimer = minTimer;

            if (xpAffect != null)
            {
                // UI objesi olduðu için Canvas'ý bulup onun içine doðurmamýz lazým
                GameObject canvas = GameObject.Find("Canvas");
                if (canvas != null)
                {
                    GameObject yazi = Instantiate(xpAffect, canvas.transform);

                    // Ekranýn neresinde çýksýn? (Örn: Tam orta)
                    yazi.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
                }
            }
        }
    }
   
}
