using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] int playerScore = 0;
    [SerializeField] int currentPopped = 0;
    [SerializeField] string playerName = "Player";
    [SerializeField] int level = 1;
    [SerializeField] int REQUIRED_POP = 15;
    [SerializeField] float gameVolume = 0.75f;
    public static PersistentData Instance;
    // Start is called before the first frame update
    private void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else {
            Destroy(Instance);
        }
            
        
    }   

    public void setScore(int s){
        playerScore = s;
    }

    public void setPopped(int p){
        currentPopped = p;
    }

    public void setName(string n){
        playerName = n;
    }

    public void setLevel(int l){
        level = l;
    }

    public void setRequiredPopped(int r){
        REQUIRED_POP = r;
    }

    public void setVolume(float v){
        gameVolume = v;
    }

    public int getScore(){
        return playerScore;
    }
    public int getPopped(){
        return currentPopped;
    }
    public string getName(){
        return playerName;
    }

    public int getLevel(){
        return level;
    }

    public int getRequiredPop(){
        return REQUIRED_POP;
    }

    public float getVolume(){
        return gameVolume;
    }

}
