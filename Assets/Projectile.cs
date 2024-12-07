using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour{

    public static int Amount = 0;
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "KILLZONE" || collision.gameObject.tag == "Bloon"){
            Destroy(gameObject);
            Amount--;
        }
    }
}
