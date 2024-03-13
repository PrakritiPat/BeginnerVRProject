using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruit : MonoBehaviour
{
    public Object wholefruit;

    private Rigidbody fruitRigidbody;
    private Collider FruitCollider;

    private void Slice()
    {
        FindObjectOfType<GameManager>().IncreaseScore();
        FruitCollider.enabled = false; 

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Slice();
        }
    }


}
