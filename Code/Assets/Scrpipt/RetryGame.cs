using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGame : MonoBehaviour
{
    public void RetryLevel()
    {
        SceneManager.LoadScene(1);
    }
}
