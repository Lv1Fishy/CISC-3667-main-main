using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnInputChange : MonoBehaviour
{
    [SerializeField] TMP_InputField input;
    [SerializeField] string username;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string username = input.text;
        submitName(username);
    }
    private void submitName(string n){
        PersistentData.Instance.setName(n);
    }
}
