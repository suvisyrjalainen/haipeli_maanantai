using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public gameStates currentGameState;
    // Start is called before the first frame update
    
    // Tämä kuunteleen P-napin painallusta
    private Master controls;
    
    public Player playerController { get; set;}

    void Awake()
    {
        controls = new Master();
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

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TogglePause();
    }

    public bool IsGamePlay()
    {
        return currentGameState == gameStates.Gameplay;
    }

    private void TogglePause()
    {
        if (controls.Game.Pause.triggered)
        {
            Debug.Log("Pause");
            if (currentGameState == gameStates.Gameplay)
            {
                currentGameState = gameStates.Pause;
            }
            else if (currentGameState == gameStates.Pause)
            {
                currentGameState = gameStates.Gameplay;
            }
        }
    }
}
