using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueTree
{
    private List<DialogueNode> nodes; // ข้อมูลการสนทนาทั้งหมด
    private int currentNodeIndex; // ตัวชี้ index ของข้อความปัจจุบัน

    public DialogueTree(List<DialogueNode> nodes)
    {
        this.nodes = nodes;
        this.currentNodeIndex = 0;
    }

    public DialogueNode GetCurrentNode()
    {
        return nodes[currentNodeIndex];
    }

    public void SetCurrentNode(int index)
    {
        currentNodeIndex = index;
    }

    public bool HasNextNode()
    {
        return GetCurrentNode().children.Count > 0;
    }

    public DialogueNode GetNextNode()
    {
        if (HasNextNode())
        {
            int nextIndex = GetCurrentNode().children[0]; // เลือกข้อความต่อไปที่ index แรก
            SetCurrentNode(nextIndex);
            return GetCurrentNode();
        }
        else
        {
            return null; // ไม่มีข้อความต่อไป
        }
    }
}
