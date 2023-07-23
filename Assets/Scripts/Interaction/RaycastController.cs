using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaycastController : MonoBehaviour
{
    private Item itemScript;
    //changes the canvas text based on what it's detecting
    [SerializeField]
    private float raycastDistance = 5.0f;

    [SerializeField]
    private float groundDistance = 2.1f;

    [SerializeField]
    //The layer that will determine what the raycast will hit
    LayerMask layerMask;
    //The UI text component that will display the name of the interactable hit
    public TextMeshProUGUI interactionInfo;

    // Update is called once per frame
    private void Update()
    {
        // Cast a ray from the camera's position forward
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits any object
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Usable") || hit.collider.CompareTag("Equippable"))
            {
                interactionInfo.GetComponent<TextMeshProUGUI>().text = hit.collider.GetComponent<Item>().id;
                
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hit.collider.gameObject.GetComponent<Item>().Interact();
                }
            }
            else
            {
                interactionInfo.GetComponent<TextMeshProUGUI>().text = "";
            }
        }
    }

    public bool isGrounded()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        return Physics.Raycast(transform.position, -transform.up, out hit, groundDistance);
    }
}