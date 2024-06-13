using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scripts : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("detect");

        if (other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
