using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour{

    [SerializeField] AudioSource soundbit;
    [SerializeField] GameObject controller;
    [SerializeField] float fixedPosition;
    [SerializeField] bool moveUp = true;
    // Start is called before the first frame update
    void Start(){
        controller = GameObject.FindGameObjectWithTag("GameController");
        soundbit = GetComponent<AudioSource>();
        fixedPosition = transform.position.y;
        InvokeRepeating("moveVertically", 0f, 0.01f);
    }

    // Update is called once per frame
    void Update(){
        
    }
    private void moveVertically(){
        if(moveUp){
            transform.position = transform.position + new Vector3(0, 0.005f, 0);
            if((fixedPosition + 0.2) <= transform.position.y){
                moveUp = false;
            }
        }
        else{
            transform.position = transform.position + new Vector3(0, -0.005f, 0);
            if((fixedPosition - 0.2) >= transform.position.y){
                moveUp = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            controller.GetComponent<Scorekeeper>().AddKey();
            AudioSource.PlayClipAtPoint(soundbit.clip, transform.position);
            Destroy(gameObject);
        }
    }
}
