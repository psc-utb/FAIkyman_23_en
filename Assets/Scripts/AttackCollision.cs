using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterBehavior attacker = this.GetComponentInParent<CharacterBehavior>();
        CharacterBehavior target = collision.gameObject.GetComponent<CharacterBehavior>();

        if (attacker != null && target != null)
        {
            attacker.Attack(target);
        }
    }

}
