using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabWeapon : MonoBehaviour
{
    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        

        Instantiate(weapon, new Vector3 (0,0,0 ), Quaternion.identity);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
