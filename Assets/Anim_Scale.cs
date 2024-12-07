using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Scale : MonoBehaviour
{
    [SerializeField] Vector2 scale;
    [SerializeField] bool b = true;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("animated", 0f, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void animated(){
        scale = transform.localScale;
        if(b){
            scale.x += 0.005f;
            scale.y += 0.005f;
            transform.localScale = scale;
            if(scale.x >= 1.2f){
                b = false;
            }
        }
        else{
            scale.x -= 0.005f;
            scale.y -= 0.005f;
            transform.localScale = scale;
            if(scale.x <= 0.8f){
                b = true;
            }
        }

    }
}
