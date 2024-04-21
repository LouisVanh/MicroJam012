using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testingTheCold : MonoBehaviour
{
    public float maxWarmth = 1f; //starting warmth
    private float currentWarmth; // how much you got left
    float howColdItIs = 0.2f;      // how much it lowers by
    public float healAmount;     // how much warmth you get back id just set it to 1
    public Image warmthImage;    // the picture you want to fade on to the screen
    public Image powerUpImage; 

    private void Start()
    {
        currentWarmth = maxWarmth;
        powerUpImage.enabled = false;
    }
       
    public void Heal()
    {
        currentWarmth = healAmount;
        currentWarmth = Mathf.Clamp(currentWarmth, 0f, maxWarmth);
        
    }

    public void Heal2()
    {
        howColdItIs = 0f;
        Invoke("coldReset", 10);
        powerUpImage.enabled = true;
    }

    public void coldReset()
    {
        howColdItIs = 1f;
        powerUpImage.enabled = false;
    }

    private void Update() // its in the name
    {
       if (currentWarmth <= 0f)
       {
            tooCold();
       }

        currentWarmth -= Time.deltaTime * howColdItIs;

        float alpha = 1f - (currentWarmth / maxWarmth);

        warmthImage.color = new Color(warmthImage.color.r, warmthImage.color.g, warmthImage.color.b, alpha);
    }

    public void tooCold()
    {
        // death function idk if you want it in here tho 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Warmth"))
        {
            Heal();           
        }

        if (other.CompareTag("Warmth2"))
        {
            Heal2();
        }
    }
}
