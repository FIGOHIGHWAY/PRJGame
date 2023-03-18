using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_KeyHolder : MonoBehaviour
{
    [SerializeField] private KeyHolder keyHolder;    
    private Transform container;
    private Transform keyTemplate;
    private QTESys qteSys;

    private void Awake(){
        container = transform.Find("container");
        keyTemplate = container.Find("keyTemplate");
    }
    
    private void Start(){
        keyHolder.OnKeysChanged += KeyHolder_OnKeysChanged;
    }

    private void KeyHolder_OnKeysChanged(object sender, System.EventArgs e){
        UpdateVisual();
    }
    
    private void UpdateVisual(){
        
        foreach (Transform child in container){
            if (child == keyTemplate) continue;
            Destroy(child.gameObject);
        }

        List<Key.KeyType> keyList = keyHolder.GetKeyList();
        for (int i = 0; i < keyList.Count; i++){
            Key.KeyType keyType = keyList[i];
            Transform keyTransform = Instantiate(keyTemplate, container);
            keyTransform.gameObject.SetActive(true);
            keyTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(100 * i, 0);
            Image keyImage = keyTransform.Find("image").GetComponent<Image>();
            switch (keyType) {
            default:
            case Key.KeyType.Red:       keyImage.sprite = keyAssets.Instance.keyDoor;     break;
            case Key.KeyType.JailDoor:  keyImage.sprite = keyAssets.Instance.crowbarDoor;   break;
            case Key.KeyType.SCDoor:    keyImage.sprite = keyAssets.Instance.SCDoor;    break;
            case Key.KeyType.Chap1OSKEY:    keyImage.sprite = keyAssets.Instance.Chap1OSKEY;    break;
            }
        }
        
    }
}