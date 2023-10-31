using HeroAndDragon_NetStandard.Characters;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterUnityWrapper : Character, ISerializationCallbackReceiver
{
    [SerializeField]
    string _name;

    [SerializeField]
    int _health;

    [SerializeField]
    int _maxDamage;

    [SerializeField]
    int _maxDefence;

    public CharacterUnityWrapper(string name, int health, int maxDamage, int maxDefence) : base(name, health, maxDamage, maxDefence)
    {
    }

    public CharacterUnityWrapper() : base(default, default, default, default)
    {
    }

    public void OnBeforeSerialize()
    {
        _health = Health;
        _name = Name;
        _maxDamage = MaxDamage;
        _maxDefence = MaxDefence;
    }

    public void OnAfterDeserialize()
    {
        Health = _health;
        MaxHealth = _health;
        Name = _name;
        MaxDamage = _maxDamage;
        MaxDefence = _maxDefence;
    }
}
