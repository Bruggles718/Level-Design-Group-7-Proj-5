using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvisibilityBehavior : MonoBehaviour
{
    public static bool IsInvis;
    public Slider InvisSlider;
    public string pickupTag;
    public int pickupAmount;
    public int lossAmount;
    public float lossTime = 1.25f;
    public AudioClip pickupsfx;
    private int currentInvis;
    private float counter;

    // Start is called before the first frame update
    void Start()
    {
        currentInvis = 100;
        IsInvis = true;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= lossTime && currentInvis >= 0) {
            counter %= lossTime;
            //Debug.Log(currentInvis);
            currentInvis -= lossAmount;
            InvisSlider.value = currentInvis;
        }

        if (currentInvis >= 0)
        {
            IsInvis = false;
        }
        // I can just set this to true with every pickup but i'm doing this just in case
        // But admittedly its not optimal 
        else if (currentInvis < 0)
        {
            IsInvis = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       ;
        if (other.CompareTag(pickupTag))
        {
            if (currentInvis < 100)
            {
                AudioSource.PlayClipAtPoint(pickupsfx,  transform.position);
                //Just some precautions
                currentInvis = Mathf.Min(100, currentInvis + pickupAmount);
                InvisSlider.value = currentInvis;
                Destroy(other.gameObject, .1f);
            }
        }
    }
}
