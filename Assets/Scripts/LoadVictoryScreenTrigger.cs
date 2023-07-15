using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadVictoryScreenTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            LevelLoader.levelLoaderInstance.LoadVictoryScreen();
        }
    }
}
