using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float[] konumlar = { -3.87f,-1.87f,0f,2f,4f};
    public int mevcutKonum = 0;
    //public float hedefKonum;
    float hareketHizi = 0f;
    public float hedefKonum;
    public float yumusatmaHizi = 0.15f;
    void Start()
    {
       hedefKonum = konumlar[mevcutKonum];
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(mevcutKonum < konumlar.Length-1)
            {
                mevcutKonum++;
                hedefKonum = konumlar[mevcutKonum];

            }            
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            if(mevcutKonum >0)
            {
                mevcutKonum--;
                hedefKonum = konumlar[mevcutKonum];
            }

        }

        float yeniY = Mathf.SmoothDamp(
            transform.position.y,
            hedefKonum,
            ref hareketHizi,
            yumusatmaHizi
            );

        transform.position = new Vector3(transform.position.x,yeniY,transform.position.z);
    }
}
