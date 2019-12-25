using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isClicked = false;
    Rigidbody2D playerRB;
    public Rigidbody2D knobRB;
    float pullPosition=2f;
    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isClicked)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector2.Distance(mousePos,knobRB.position)>pullPosition)
            {
                playerRB.position = knobRB.position + (mousePos - knobRB.position).normalized * pullPosition;
            }
            else
            {
                playerRB.position = mousePos;
            }
        }
    }

    private void OnMouseDown()
    {
        isClicked = true;
        playerRB.isKinematic = true;
    }
    private void OnMouseUp()
    {
        isClicked = false;
        playerRB.isKinematic = false;
        StartCoroutine(DelayRelease());
    }

    IEnumerator DelayRelease()
    {
        yield return new WaitForSeconds(0.1f);

        GetComponent<SpringJoint2D>().enabled = false;
    }
}
