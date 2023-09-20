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



        if (fireTimer > fireRate && MamaStartsShooting) //ska skjuta om mamastartshooting �r lika med true och fireTimern �r h�gre �n fireRaten. 
        {
           fireTimer = 0; //resetar fireTimern f�r varje shoot. 
           MamaShooting(); // kallar p� funktionen
        }

        fireTimer += Time.deltaTime;
    }


    void MamaShooting()
    {

        GameObject mamaBullet = Instantiate(ProjectileMama, bulletPoint.position, transform.rotation); // instantierar projctilen hos mama, bulletPoint = startpositionen p� maman/objektet d�r skottet ska ut.
                                                                                                       // tranform.rotation = rotation. 
        //Rigidbody2D projectile = ProjectileMama.GetComponent<Rigidbody2D>();
        //projectile.velocity = bulletPoint.up * fireRate;


    }


}


