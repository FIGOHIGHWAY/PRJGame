using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoveMent : MonoBehaviour
{
    public float moveSpeed = 5f; // ความเร็วการเคลื่อนที่ของตัวละคร NPC

    private void Update()
    {
        MoveRight();
    }

    private void MoveRight()
    {
        // ตั้งค่าทิศทางเคลื่อนที่ของตัวละคร NPC ให้เป็นทิศทางขวา
        Vector2 movement = new Vector2(1f, 0f);
        
        // เคลื่อนที่ตัวละคร NPC โดยใช้ฟังก์ชั่น Translate()
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
