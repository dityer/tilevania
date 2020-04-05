using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinzPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickUpSFX;
    [SerializeField] int pointsForCoinPickup = 100;
    bool isCollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Your player has got more than one collider, hasn't he? If so, it might be that more than one collider touched the trigger collider, 
        // thus the OnTriggerEnter2D method gets called twice.
        // Add a bool variable to the top of your Coin class, for example, isCollected.In the OnTriggerEnter2D method, 
        // check if the variable is true before you execute the code.When the method was called for the first time and 
        // the code was executed, set the bool variable to true.
        if (!isCollected)
        {
            isCollected = true;
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
