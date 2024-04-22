using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Ammo : MonoBehaviour
{

    private float lifeTimer;
    
    // Tämä suoritetaan kun enabloidaan playerin toimesta
    private void OnEnable()
    {
        lifeTimer = 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * -5 * Time.deltaTime);

        lifeTimer -= Time.deltaTime;

        if(lifeTimer <= 0)
        {
            BulletPoolManager.Instance.ReturnBullet(gameObject);
        }
    }
}
