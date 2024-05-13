using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float currentSpeed = 1f;
    public Rigidbody2D body;
    // Start is called before the first frame update
    private Transform playerTransform;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetPlayer()
   {
    
       if(playerTransform == null)
       {
           playerTransform = GameManager.instance.playerController.transform;
       }
   }


}
