using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public void ToggleSound()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
