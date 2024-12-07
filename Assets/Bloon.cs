using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bloon : MonoBehaviour{
    [SerializeField] AudioSource soundbit;
    [SerializeField] GameObject controller;
    [SerializeField] Vector2 scale;
    [SerializeField] int score = 100;
    [SerializeField] float scalingScore = 1f;
    [SerializeField] float fixedPosition;
    [SerializeField] bool moveUp = true;

    void Start(){
        controller = GameObject.FindGameObjectWithTag("GameController");
        soundbit = GetComponent<AudioSource>();
        fixedPosition = transform.position.y;
        InvokeRepeating("growInSize", 0.5f, 0.1f);
        InvokeRepeating("moveVertically", 0f, 0.01f);
        InvokeRepeating("reduceScore", 0.5f, 0.5f);
    }

    void Update(){
        
    }

    private void reduceScore(){
        scalingScore += 0.05f;
        score = (int)System.MathF.Floor(score - scalingScore);
        if(score <= 0){
            score = 0;
        }
    }

    private void growInSize(){
        scale = transform.localScale;
        scale.x += 0.002f;
        scale.y += 0.002f;
        transform.localScale = scale;
        if(scale.x >= 0.5f){
            SceneManager.LoadScene(PersistentData.Instance.getLevel());
        }
    }

    private void moveVertically(){
        if(moveUp){
            transform.position = transform.position + new Vector3(0, 0.01f, 0);
            if((fixedPosition + 0.5) <= transform.position.y){
                moveUp = false;
            }
        }
        else{
            transform.position = transform.position + new Vector3(0, -0.01f, 0);
            if((fixedPosition - 0.5) >= transform.position.y){
                moveUp = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Projectile"){
            controller.GetComponent<Scorekeeper>().AddPoints(score);
            AudioSource.PlayClipAtPoint(soundbit.clip, transform.position);
            Destroy(gameObject);
        }
    }
}
