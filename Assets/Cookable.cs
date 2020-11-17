using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookable : MonoBehaviour, ICookable
{
    public enum CookingState{RAW, COOKED, BURNED};
    public Material rawMaterial;
    public Material cookedMaterial;
    public Material burnedMaterial;
    public GameObject burger;

    [SerializeField]
    private CookingState currentState = CookingState.RAW;
    [SerializeField]
    private float changeStateAmount = 100;
    [SerializeField]
    private float currentCookedAmount = 0;

    private MeshRenderer burgerMaterial;

    public void Cook(float heatAmount)
    {
        currentCookedAmount += heatAmount;
    }

    // Start is called before the first frame updates
    void Start()
    {
        burgerMaterial = burger.GetComponentInChildren<MeshRenderer>();
        burgerMaterial.material = rawMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentCookedAmount > changeStateAmount)
        {
            currentCookedAmount = 0;
            NextState();
        }
    }

    private void NextState()
    {
        if(currentState == CookingState.RAW)
        {
            currentState = CookingState.COOKED;
            burgerMaterial.material = cookedMaterial;
        }
        else if(currentState == CookingState.COOKED )
        {
            currentState = CookingState.BURNED;
            burgerMaterial.material = burnedMaterial;
        }
    }
}
