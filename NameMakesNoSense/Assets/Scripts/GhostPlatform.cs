using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlatform : MonoBehaviour //Ghostplatform script to add to any script I want to make blink and disappear
{
    [SerializeField] string playerTag = "Player";
    [SerializeField] float disappearTime = 3;
    Animator myAnim;

    [SerializeField] bool canReset;
    [SerializeField] float resetTime;


    void Start()
    {
        myAnim = GetComponent<Animator>(); //vi letar efter en animator och kopplar den till myAnim
        myAnim.SetFloat("DisappearTime", 1 / disappearTime); //disappearTime animation är 1sekund lång. vi dividerar med tiden det vi vill ha.

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == playerTag)
        {
            myAnim.SetBool("Trigger", true); //trigga transitionen mellan waiting state och animationen för fading
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == playerTag)
        {
            myAnim.SetBool("Trigger", true);
        }
    }

    public void TriggerReset()
    {
        if (canReset)
        {
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset() //Läs på mer om IEnumerators och kolla föreläsningarna igen
    {
        yield return new WaitForSeconds(resetTime);
        myAnim.SetBool("Trigger", false);
    }
}
