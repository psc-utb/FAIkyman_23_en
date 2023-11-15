using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitNumberManagement : MonoBehaviour
{
    [SerializeField]
    GameObject hitNumberPrefab;

    
    public void CreateHitNumber(GameObject character, int hitValue)
    {
        GameObject go = Instantiate(hitNumberPrefab);
        go.transform.position = character.transform.position;

        TextMeshPro textMeshPro = go.GetComponent<TextMeshPro>();

        textMeshPro.text = string.Empty;
        if (hitValue < 0)
        {
            textMeshPro.color = Color.red;
        }
        else if(hitValue > 0)
        {
            textMeshPro.color = Color.green;
            textMeshPro.text = "+";
        }
        else
        {
            textMeshPro.color = Color.blue;
        }
        textMeshPro.text = hitValue.ToString();

        Rigidbody2D rigidBody2D = go.GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = new Vector2(0, 2);

        Destroy(go, 2);
    }
}
