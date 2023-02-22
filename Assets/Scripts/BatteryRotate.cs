using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryRotate : MonoBehaviour
{
    public float speed;
    public float rot = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rot += speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, rot, 0);
        //if(rot > 360) { rot = 0; }
    }
}
