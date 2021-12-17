using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteractionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Ray interactionRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit interactionInfo;
            //Debug.DrawRay(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2)), transform.forward * 5, Color.red, 20);
            if (Physics.Raycast(interactionRay, out interactionInfo, 5))
            {
                GameObject interactedObject = interactionInfo.collider.gameObject;
                if (interactedObject.tag == "Interactable Object")
                {
                    interactedObject.GetComponent<Interactable>().Interact();
                }
            }
        }
    }
}
