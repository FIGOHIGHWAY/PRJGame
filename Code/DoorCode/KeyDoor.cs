using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;
    
    
    private Key key;
    private SpriteRenderer spriteRenderer;

    public Key.KeyType GetKeyType() {
        return keyType;
    }

    
    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetItem(Key key)
    {
        this.key = key;
    }

    public Key GetItem(){
        return key;
    }

    
}
