using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyNewEmployee : MonoBehaviour
{

    public Sprite ghostEmployee;
    public ParticleSystem cloud;

    void Start()
    {
        cloud.gameObject.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void PurchaseEmployee()
    {
        
        cloud.gameObject.SetActive(true);
        cloud.Play();
    }
}
