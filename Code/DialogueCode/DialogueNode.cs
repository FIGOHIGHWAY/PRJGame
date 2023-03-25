using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueNode
{
    public string speakerName; // ชื่อตัวละครที่พูด
    public List<Sprite> speakerSprites; // รูปภาพตัวละคร
    public int currentSpriteIndex; // ลำดับของรูปภาพตัวละครปัจจุบัน
    public string text; // ข้อความที่พูด
    public List<int> children; // เก็บ index ของข้อความต่อไป

    public DialogueNode(string speakerName, List<Sprite> speakerSprites, string text)
    {
        this.speakerName = speakerName;
        this.speakerSprites = speakerSprites;
        this.currentSpriteIndex = 0; // กำหนดลำดับของรูปภาพเป็น 0 เริ่มต้น
        this.text = text;
        this.children = new List<int>();
    }

    public void ChooseSpeaker(string speakerName, List<Sprite> speakerSprites, int spriteIndex)
    {
        this.speakerName = speakerName;
        this.speakerSprites = speakerSprites;
        this.currentSpriteIndex = spriteIndex;
    }
}
