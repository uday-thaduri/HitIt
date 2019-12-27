using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{

    public Rigidbody2D knobRB;
    public GameObject nextPlayer;
    public UIManager uim;
    public GameObject particleObject;
    public GameObject scoreBall;

    SpriteRenderer spRender;
    TrailRenderer tRender;
    bool isClicked = false;
    Rigidbody2D playerRB;
    float pullPosition = 2f;
    int particleCount = 1;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        spRender = GetComponent<SpriteRenderer>();
        tRender = GetComponent<TrailRenderer>();


    }

    private void Update()
    {
        if (isClicked)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(mousePos, knobRB.position) > pullPosition)
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
        tRender.enabled = false;
    }
    private void OnMouseUp()
    {
        isClicked = false;
        playerRB.isKinematic = false;
        tRender.enabled = true;
        StartCoroutine(DelayRelease());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bottles" && particleCount==1)
        {
            Instantiate(particleObject, transform.position, Quaternion.identity);

            particleCount--;
        }

    }
    IEnumerator DelayRelease()
    {
        yield return new WaitForSeconds(0.1f);

        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
        yield return new WaitForSeconds(3f);

        spRender.enabled = false;
        tRender.enabled = false;
        if (nextPlayer != null)
        {
            scoreBall.SetActive(false);
            nextPlayer.SetActive(true);
            
        }
        else
        {
            scoreBall.SetActive(false);
            Bottle.noOfBottles = 0;
            uim.GameOver();
        }


    }
}
