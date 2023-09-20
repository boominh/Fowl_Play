using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        float posX = transform.position.x;
        float posY = transform.position.y;
        float posZ = transform.position.z;

        float anchorY = posY + 1;
        float frequency = 1;
        float amplitude = 1 / 2;
        float timer = Time.deltaTime;

        posY = anchorY + Mathf.Sin(timer*frequency) * amplitude;

        gameObject.transform.position =  new Vector3 ( posX, posY, posZ);
    }
}
