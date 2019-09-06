using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldData : MonoBehaviour
{
    public string characterName;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
