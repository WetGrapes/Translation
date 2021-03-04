using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Output : MonoBehaviour
{
    public TextMeshProUGUI OutputField;
    public static Output Component { private set; get; }
    // Start is called before the first frame update
    void Awake()
    {
        OutputField = GetComponent<TextMeshProUGUI>();
        Component = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
