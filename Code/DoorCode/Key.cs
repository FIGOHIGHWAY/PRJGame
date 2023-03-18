using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] public KeyType keyType;

    public enum KeyType{
        Red,
        JailDoor,
        SCDoor,
        Chap1OSKEY
    }

    public KeyType GetKeyType(){
        return keyType;
    }
       
}
