using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class SymbolTable
{
    private static int lst = 'a';
    private Dictionary<char, string> _chsd = new Dictionary<char, string>();
    string str = "";
    public SymbolTable() => lst = 'a';

    private string GetValue(char key)
    {
        try
        {
            if (_chsd.TryGetValue(key, out str)) return str;
            throw new Exception();
        } catch(Exception e) {
            return "--";
        }
    }

    private void SetValue(char key, string value)
    {
        _chsd.Add(key, value);
    }

    public string this[char key]
    {
        get => GetValue(key);
        set => SetValue(key, value);
    }

    public string LastValue => this[LastKey];
    public char LastKey => (char) (lst - 1);

    public char Add(string value)
    {
        if (_chsd.ContainsValue(value))
        {
            foreach (var pair in _chsd)
            {
                if (value == pair.Value) return pair.Key;
            }
        }
        else
        {
            _chsd.Add((char)lst, value);
            lst++;
        }

        return LastKey;
    }
    public static implicit operator char(SymbolTable t) => t.LastKey;
    public static char operator +(SymbolTable a, string b) => a.Add(b);
}

public static class Addresses
{
    public static SymbolTable SymbolTable = new SymbolTable();
}