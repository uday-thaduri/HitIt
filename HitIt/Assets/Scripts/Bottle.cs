using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public static int noOfBottles = 0;
    public UIManager ui;


    private void Start()
    {

        noOfBottles++;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

            Destroy(gameObject);
            BottleDrop();

        }

    }

    public void BottleDrop()
    {
        noOfBottles--;
        if (noOfBottles == 0)
        {
            ui.GameOver();
        }

    }
}
