using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseResume : MonoBehaviour{
    [SerializeField] GameObject Pausing;
    [SerializeField] GameObject Resuming;
    [SerializeField] bool isPaused;

    // Start is called before the first frame update
    void Start(){
        isPaused = false;
    }

    // Update is called once per frame
    void Update(){
        if(isPaused){
            Time.timeScale = 0f;
        }
        else{
            Time.timeScale = 1f;
        }
    }

    public void Pause(){
        isPaused = true;
        Pausing.SetActive(true);
        Resuming.SetActive(false);
    }

    public void Resume(){
        isPaused = false;
        Pausing.SetActive(false);
        Resuming.SetActive(true);
    }
}
