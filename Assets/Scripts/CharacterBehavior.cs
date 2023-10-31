using CodeMonkey.HealthSystemCM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour, IGetHealthSystem
{
    [SerializeField]
    CharacterUnityWrapper character;

    HealthSystem _healthSystem;

    void Awake()
    {
        _healthSystem = new HealthSystem(character.MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("");
    }


    public HealthSystem GetHealthSystem()
    {
        return _healthSystem;
    }
}
