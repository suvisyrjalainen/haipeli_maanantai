using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Pelaajan liikkumisnopeus ns liikkumisen kerroin
    public float moveSpeed = 5f;

    public Rigidbody2D body;

    // Tämä kuuntelee kaikki pelaajan wasd ja nuolinäppäimien painallukset
    private Master controls;
    // Tähän tallennetaan nappien painallukset x ja y akselilla

    private Vector2 moveInput;

    private Vector2 aimInput;

    // Tämä on pelaajan aseen paikka suunta ja skaalaus
    public Transform gunTransform;
    
    // Tämä suoritetaan ennen pelin käynnistystä
    private void Awake()
    {
        controls = new Master();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        Shoot();
    }

    private void OnEnable(){
        controls.Enable();
    }

    private void OnDisable(){
        controls.Disable();
    }

    private void FixedUpdate(){
        Move(); 
    }

    private void Move(){
        moveInput = controls.Player.Move.ReadValue<Vector2>();
        Vector2 movement = new Vector2(moveInput.x, moveInput.y) * moveSpeed * Time.fixedDeltaTime;
        body.MovePosition(body.position + movement);
    }

    private void Shoot(){
        if(controls.Player.Shoot.triggered){
            Debug.Log("Shoot");
            GameObject bullet = BulletPoolManager.Instance.GetBullet();
            bullet.transform.position = gunTransform.position;
            bullet.transform.rotation = gunTransform.rotation;
        }
    }

    private void Aim(){
        aimInput = controls.Player.Aim.ReadValue<Vector2>();
        //Tarkistetaan että pelaaja on antanut inputtia
        if(aimInput.sqrMagnitude > 0.1f){
            //Tässä rivissä asetetaan aseen suunta (gunTransform.up) 
            //pelaajan antaman inputin mukaiseksi. 
            //Tämä tarkoittaa, että ase osoittaa kohti sitä suuntaa, 
            //johon pelaaja haluaa ampua. Ammus kulkee koodissamme miinussuuntaan
            //ja siksi suunta up on tässä vähän hämäävä.
            gunTransform.up = aimInput;
            //Lasketaan kulma johon pelaajan ase osoittaa. 
            //Mathf.Atan2-funktio laskee kulman kahden pisteen välillä, ja se ottaa 
            //argumentteina x- ja y-koordinaatit. Mathf.Rad2Deg 
            //muuntaa tuloksen radiaaneista asteiksi.
            float angle = (Mathf.Atan2(aimInput.x, -aimInput.y)) * Mathf.Rad2Deg;
            //Tässä asetetaan aseen kulma (gunTransform.rotation) 
            //lasketun kulman mukaiseksi. Quaternion.Euler luo rotaatioquaternionin 
            //annetuilla kulma-arvoilla. Aseen kulmaa päivitetään asettamalla 
            //Z-akselin kulma (angle). Tämä saa aseen kääntymään oikeaan suuntaan.
            gunTransform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

}
