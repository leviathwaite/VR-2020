using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{

    [SerializeField]
    private float heatAmount = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // TODO turn on smoke or cooking effect
    }

    private void OnTriggerStay(Collider other)
    {
        ICookable cookable = other.GetComponent<ICookable>();

        if(cookable != null)
        {
            cookable.Cook(heatAmount);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // TODO turn off smoke or cooking effect
    }
}
