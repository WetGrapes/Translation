using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Input : MonoBehaviour
{
    public TMP_InputField InputField;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        InputField = GetComponent<TMP_InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        Output.Component.OutputField.text = InputField.text;
    }
}
