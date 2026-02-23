using UnityEngine;
using TMPro; // TextMeshPro kullandýðýn için gerekli

public class XPEffect : MonoBehaviour
{
    public float moveSpeed = 0.8f;  // Yukarý çýkma hýzý
    public float fadeSpeed = 0.5f;  // Kaybolma hýzý (Küçüldükçe daha yavaþ silinir)
    public float destroyTime = 2.5f; // Toplam kaç saniye yaþasýn?

    private TextMeshProUGUI textMesh;
    private Color textColor;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        if (textMesh != null)
        {
            textColor = textMesh.color;
        }

        // Zamaný gelince objeyi tamamen yok et
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        // 1. Yazýyý yukarý kaydýr
        transform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);

        // 2. Rengi yavaþça þeffaflaþtýr
        if (textMesh != null)
        {
            textColor.a -= fadeSpeed * Time.deltaTime;
            textMesh.color = textColor;
        }
    }
}