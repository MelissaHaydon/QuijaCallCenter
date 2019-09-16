using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    int indexOfPosition;
    public int maxIndex;

    public GameObject[] itemScreens;

    void Start()
    {
        indexOfPosition = 0;
        maxIndex = 1;
        itemScreens[1].SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void RightArrow()
    {
        if (indexOfPosition < maxIndex)
        {
            itemScreens[indexOfPosition].SetActive(false);
            indexOfPosition++;
            itemScreens[indexOfPosition].SetActive(true);
        }
    }

    public void LeftArrow()
    {
        if (indexOfPosition > 0)
        {
            itemScreens[indexOfPosition].SetActive(false);
            indexOfPosition--;
            itemScreens[indexOfPosition].SetActive(true);
        }
    }
}
