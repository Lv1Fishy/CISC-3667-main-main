using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour{
    [SerializeField] int NUM_BLOONS = 5;
    [SerializeField] GameObject Bloon;
    [SerializeField] float xMin = 0;
    [SerializeField] float xMax = 0;
    [SerializeField] float yMin = 0;
    [SerializeField] float yMax = 0;
    void Start(){
        Bloon = GameObject.FindGameObjectWithTag("Bloon");
        Spawn();
    }

    void Update(){
        
    }

    void Spawn(){
        Vector2 position;
        for(int i = 0; i < NUM_BLOONS; i++){
            position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(Bloon, position, Quaternion.identity);
        }
    }
}
