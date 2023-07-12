using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{  
    [SerializeField] AudioSource playerReviveSound;
    bool isDead = false;
    int counterDeath;
    
    void Start()
    {
        counterDeath = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Kill Zone") && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMoviment>().enabled = false;
        playerReviveSound.Play();
        isDead = true;
        Invoke(nameof(ReloadLevel), 2f); //call the func ReloadLevel after 2seconds
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
