using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision other) 
    {
        Debug.Log("OnCollisionEnter");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
