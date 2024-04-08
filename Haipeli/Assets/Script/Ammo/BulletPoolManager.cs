using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    //Tämä koska tähän objektiin/fileen otetaan monesta paikasta yhteyttä
    public static BulletPoolManager Instance;
    
    //Tämä on ammuksen aihio
    public GameObject bulletPrefab;

    //Tämä on ammusten määrä
    public int bulletAmount = 20;

    //Tämä on ammusten pooli
    private Queue<GameObject> bulletPool = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        //Tämä osoittaa tähän peliobjektiin
        Instance = this;
        InitializePool();

    }

    private void InitializePool(){
        //Tämä luo ammusjonon
        for (int i = 0; i < bulletAmount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet(){
        //Tämä ottaa ammuksen jonosta
        if(bulletPool.Count > 0){
            GameObject bullet = bulletPool.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else{
            //GameObject bullet = Instantiate(bulletPrefab);
            return null;
        }
    }
}
