using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MamaIsShooting : MonoBehaviour
{

    public GameObject ProjectileMama;
    
    float fireTimer;
    float fireRate = 2f;
    public Transform bulletPoint;
    bool MamaStartsShooting = true;


    // Start is called before the first frame update
    void Start()
    {
        fireTimer = fireRate;
       
    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetMouseButtonDown(1))
        //{
        //    fireTimer = 0;
        //    MamaShooting();
        //}



        if (fireTimer > fireRate && MamaStartsShooting) //ska skjuta om mamastartshooting är lika med true och fireTimern är högre än fireRaten. 
        {
           fireTimer = 0; //resetar fireTimern för varje shoot. 
           MamaShooting(); // kallar på funktionen
        }

        fireTimer += Time.deltaTime;
    }


    void MamaShooting()
    {

        GameObject mamaBullet = Instantiate(ProjectileMama, bulletPoint.position, transform.rotation); // instantierar projctilen hos mama, bulletPoint = startpositionen på maman/objektet där skottet ska ut.
                                                                                                       // tranform.rotation = rotation. 
        //Rigidbody2D projectile = ProjectileMama.GetComponent<Rigidbody2D>();
        //projectile.velocity = bulletPoint.up * fireRate;


    }


}


