using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] float timeBeforeDestroy;
    int countCoins = 0;
    [SerializeField] Text coinsText;
    [SerializeField] AudioSource grabCoinSound;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Coin"))
        {
            collider.gameObject.GetComponent<Rotate>().speedY = 5;
            grabCoinSound.Play();
            Destroy(collider.gameObject, timeBeforeDestroy);
            countCoins++;
            coinsText.text = "Coins: " + countCoins;
            
        }
    }
}
