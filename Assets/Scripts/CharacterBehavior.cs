using CodeMonkey.HealthSystemCM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterBehavior : MonoBehaviour, IGetHealthSystem
{
    [SerializeField]
    CharacterUnityWrapper character;

    HealthSystem _healthSystem;

    public UnityEvent<GameObject> Died;

    void Awake()
    {
        _healthSystem = new HealthSystem(character.MaxHealth);

        character.HealthChanged += Character_HealthChanged;
    }

    

    // Update is called once per frame
    void Update()
    {
    }

    public HealthSystem GetHealthSystem()
    {
        return _healthSystem;
    }

    public void Attack(CharacterBehavior target)
    {
        if (target.character.IsAlive())
        {
            int damage = this.character.Attack(target.character);
            target._healthSystem.SetHealth(target.character.Health);
        }
    }

    private void Character_HealthChanged(int arg1, int arg2)
    {
        
        if (character.IsAlive() == false)
        {
            Died?.Invoke(this.gameObject);
        }
    }

}
