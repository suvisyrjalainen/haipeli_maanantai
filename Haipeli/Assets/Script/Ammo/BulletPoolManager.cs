using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    //Tämä koska tähän objektiin/fileen otetaan monesta paikasta yhteyttä
    public static BulletPoolManager Instance;
    
    //Tämä on ammuksen aihio
    public GameObject bulletPrefab;

    //Tämä ammusten määrä
    public int bulletAmount = 20;

    private Queue<GameObject> bulletPool = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
