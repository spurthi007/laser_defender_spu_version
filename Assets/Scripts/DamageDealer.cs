using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int Damage { get; } = 20;
    

    public void Hit()
    {
        //Debug.Log("Destroying " + gameObject);
        
        Destroy(gameObject);
    }

}
