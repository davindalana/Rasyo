using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    public int sceneBuildingIndex;

    private void OnTriggerEnter2D(Collider2D other) {
        print("Trigger Entered");

        if(other.tag == "Player") {
            print("Switching Scene To " + sceneBuildingIndex);
            Debug.Log("Switch Scene To");
            Debug.Log("trigger Entered");
            SceneManager.LoadScene(sceneBuildingIndex, LoadSceneMode.Single);
        }
    }
}
