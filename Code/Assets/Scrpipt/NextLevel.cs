using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] GameObject[] elementsToFinish;
    [SerializeField] string nextLevelText;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Player" && getAllCollectibles())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    bool getAllCollectibles(){
        foreach (GameObject element in elementsToFinish)
        {
            if (element != null)
            {
                return false;
            }
            
        }
        return true;
    }
}
