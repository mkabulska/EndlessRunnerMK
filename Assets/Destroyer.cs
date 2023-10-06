using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If object collides with it , its tagged
        if (collision.gameObject.tag == "CleanUp")
        {
            //this destroys it
            Destroy(collision.gameObject);
        }
    }

}
