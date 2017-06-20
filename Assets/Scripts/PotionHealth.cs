using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionHealth : MonoBehaviour, IConsummable
{
    public void Consume()
    {
        Debug.Log("you drink the potion");
    
    }

    public void Consume(CharacterStats Stats)
    {
        Debug.Log("you drink the potion one time");
    }
}
