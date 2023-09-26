using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeAppearancePickup : MonoBehaviour
{
    [SerializeField] public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject; // Assign the GameObject itself

            // Find the child GameObject named "arm"
            Transform rightArmTransform = other.transform.Find("GFX/Bodyparts/RightArm");
            Transform leftArmTransform = other.transform.Find("GFX/Bodyparts/LeftArm");
            Transform miscTransform = other.transform.Find("GFX/Bodyparts/Misc");
            Transform bodyTransform = other.transform.Find("GFX/Bodyparts/Body");
            Transform HockeyTransform = other.transform.Find("GFX/Bodyparts/HockeySet");


            // Check if "arm" was found
            if (rightArmTransform != null && leftArmTransform != null && miscTransform != null && bodyTransform != null && HockeyTransform != null)
            {
                // Disable the "arm" GameObject
                rightArmTransform.gameObject.SetActive(false);
                leftArmTransform.gameObject.SetActive(false);
                miscTransform.gameObject.SetActive(false);
                bodyTransform.gameObject.SetActive(false);
                HockeyTransform.gameObject.SetActive(true);
            }
        }
        Destroy(gameObject);
    }
}
