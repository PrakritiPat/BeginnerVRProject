using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class blade : MonoBehaviour
{

    [SerializeField] GameObject sword;
    [SerializeField] string slashTag;
    private void Update()
    {

      //  IncreaseScore();
  
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        if (other.gameObject.tag == slashTag)
        {
            Debug.Log("slash");
            Destroy(other.gameObject);
           // FindObjectOfType<GameManager>().IncreaseScore();

        }

    }


}
