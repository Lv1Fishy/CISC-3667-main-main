using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Scorekeeper : MonoBehaviour{
    [SerializeField] int score;
    [SerializeField] int pop;
    [SerializeField] int level;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI playerText;
    [SerializeField] int CURRENT_STAGE_REQ_POP;
    [SerializeField] GameObject controller;
    [SerializeField] int keyObtained = 0;
    [SerializeField] int keyRequired = 1;
    void Start(){
        score = PersistentData.Instance.getScore();
        pop = PersistentData.Instance.getPopped();
        level = PersistentData.Instance.getLevel();
        CURRENT_STAGE_REQ_POP = PersistentData.Instance.getRequiredPop();
        controller = GameObject.FindGameObjectWithTag("GameController");
        displayScore();
        displayLevel();
        displayPlayerName();
    }

    public void AddPoints(int points){
        score += points;
        pop += 1;
        displayScore();
        if(pop >= PersistentData.Instance.getRequiredPop()){
            CURRENT_STAGE_REQ_POP += 20;
            level++;
            PersistentData.Instance.setScore(score);
            PersistentData.Instance.setPopped(pop);
            PersistentData.Instance.setRequiredPopped(CURRENT_STAGE_REQ_POP);
            PersistentData.Instance.setLevel(level);
            displayLevel();
            nextLevel();
        }
    }

    public void AddKey(){
        keyObtained++;
        if(keyObtained >= keyRequired){
            destroyWalls();
        }
    }

    private void destroyWalls(){
        GameObject[] unlockableWalls = GameObject.FindGameObjectsWithTag("Unlock");
        foreach(GameObject unlock in unlockableWalls){
            Destroy(unlock);
        } 
    }
    
    private void displayScore(){
        scoreText.text = "Score: " + score;
    }

    private void displayLevel(){
        levelText.text = "Level: " + PersistentData.Instance.getLevel();
    }

    private void displayPlayerName(){
        playerText.text = "Hello, " + PersistentData.Instance.getName();
    }
    private void nextLevel(){
        SceneManager.LoadScene(PersistentData.Instance.getLevel());
    }

}
