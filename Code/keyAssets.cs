using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyAssets : MonoBehaviour
{
    public static keyAssets Instance { get; private set; }

    private void Awake(){
        Instance = this;
    }

    public Transform pfItemWorld;
    
    public Sprite keyDoor;
    public Sprite crowbarDoor;
    public Sprite SCDoor;
    public Sprite Chap1OSKEY;
}
