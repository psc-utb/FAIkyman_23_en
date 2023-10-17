using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField]
    GameObject weapon;

    public void SwordEnable()
    {
        if(weapon != null)
            weapon.SetActive(true);
    }

    public void SwordDisable()
    {
        if (weapon != null)
            weapon.SetActive(false);
    }
}
