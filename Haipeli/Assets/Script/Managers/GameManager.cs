using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public gameStates currentGameState;
    // Start is called before the first frame update
    

    void Awake()
    {
        //Sinletonin idea on että tätä komponenttia on vain yksi per peli
        //Tällä varmistetaan, että pelissä on vain yksi GameManager
        if (instance == null)
        {
            instance = this;
            //Tämä säilyy kun vaihdetaan sceneä
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
