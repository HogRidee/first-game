using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header ("Ventilation SFX Test")]
    [field: SerializeField] public EventReference ventilationSFXTest{get; private set;}
    
    [field: Header ("Monster SFX Test")]
    [field: SerializeField] public EventReference monsterSFXTest{get; private set;}
    
    [field: Header ("Drip SFX Test")]
    [field: SerializeField] public EventReference dripSFXTest{get; private set;}
    
    [field: Header ("Metal SFX Test")]
    [field: SerializeField] public EventReference metalSFXTest{get; private set;}
    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("FMODEvents instance already exists!");
        }
        instance = this;
    }
}
