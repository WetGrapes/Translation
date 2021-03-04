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

    private string outputBuf, tempBuf;
    private SemanticType typeBuf = SemanticType.nulltype;
    private List<KeyValuePair<SemanticType, string>> tree;

    private bool er;
    // Update is called once per frame
    void Update()
    {
        if (InputField.text.Length==0)  return;
        if (InputField.text[InputField.text.Length-1] != '=') return;
        var buffer = InputField.text.Trim(' ');
        outputBuf = "";
        tempBuf = "";
        typeBuf = SemanticType.nulltype;
        tree = new List<KeyValuePair<SemanticType, string>>();
        er = false;
        char c;
        for (var i = 0; i < buffer.Length; i++)
        {
            c = buffer[i];
            if (c == '=')
            {
                tree.Add(new KeyValuePair<SemanticType, string>(typeBuf, tempBuf));
                break;
            }
            if ( WhichType(c) != SemanticType.oper)
            {
                typeBuf = WhichType(c);
                tempBuf += buffer[i];
            }
            else 
            {
                if (typeBuf == SemanticType.oper)
                {
                    er = true;
                    outputBuf = "Invalid expression";
                    break;
                }
                tree.Add(new KeyValuePair<SemanticType, string>(typeBuf, tempBuf));
                typeBuf = WhichType(c);
                tempBuf = ""+c;
                tree.Add(new KeyValuePair<SemanticType, string>(typeBuf, tempBuf));
                tempBuf = "";
            }
        }
       
        if (!er) for (var i = 0; i < tree.Count; i++)
        {
            if(tree[i].Key == SemanticType.oper){
                outputBuf += tree[i+1].Value + " ";
                outputBuf += tree[i].Value + " ";
                i++;
            } else
                outputBuf += tree[i].Value + " ";
        }

        Output.Component.OutputField.text = outputBuf;
    }

    private SemanticType WhichType(char c)
    {
        if (char.IsDigit(c)) return SemanticType.digit;
        if (c == '+' || c == '-') return SemanticType.oper;
        return SemanticType.nulltype;
    }
}

public enum SemanticType
{
    digit,
    oper,
    expr,
    nulltype
}


/*
 if (typeBuf == SemanticType.oper && WhichType(c) == SemanticType.oper)
            {
                er = true;
                outputBuf = "Invalid expression";
                break;
            }
            */