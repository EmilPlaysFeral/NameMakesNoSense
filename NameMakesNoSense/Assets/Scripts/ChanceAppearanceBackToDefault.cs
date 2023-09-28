using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceAppearanceBackToDefault : MonoBehaviour
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
            Transform hockeyTransform = other.transform.Find("GFX/Bodyparts/HockeySet");


            // Check if "arm" was found
            if (rightArmTransform != null && leftArmTransform != null && miscTransform != null && bodyTransform != null && hockeyTransform != null)
            {
                // Disable the "arm" GameObject
                rightArmTransform.gameObject.SetActive(true);
                leftArmTransform.gameObject.SetActive(true);
                miscTransform.gameObject.SetActive(true);
                bodyTransform.gameObject.SetActive(true);

                if (hockeyTransform.gameObject.activeSelf == true)
                {
                    hockeyTransform.gameObject.SetActive(false);
                }
            }
        }
        Destroy(gameObject);
    }
}
