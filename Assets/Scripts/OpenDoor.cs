using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenDoor : MonoBehaviour
{
    public TMP_Text textDisplay;
    public GameObject door;
    float distanceFromButton;
    GameObject hitObject;
    private bool isOpening = false;

    // Update is called once per frame
    void Update()
    {
        distanceFromButton = PlayerCasting.distanceFromTarget;
        hitObject = PlayerCasting.hitTarget;
        if(Input.GetButtonDown("Action") && distanceFromButton <= 2
            && hitObject.Equals(gameObject) && isOpening == false)
        {
            StartCoroutine(OpenDoorAnimation());
        }
    }

    private void OnMouseOver()
    {
        if (distanceFromButton <= 2 && isOpening == false)
        {
            textDisplay.text = "[E] Open Door";
        }
        else
        {
            textDisplay.text = "";
        }
    }

    private void OnMouseExit()
    {
        textDisplay.text = "";
    }


    private IEnumerator OpenDoorAnimation()
    {
        isOpening = true;
        door.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(2);
        door.GetComponent<Animator>().enabled = false;
        yield return new WaitForSeconds(5);
        door.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(2);
        door.GetComponent<Animator>().enabled = false;
        isOpening = false;
    }
}
