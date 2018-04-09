using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchScript : MonoBehaviour
{
    public Camera c;
    void Update()
    {
        //for (var i = 0; i < Input.touchCount; ++i)
        //{
        if (Input.touchCount == 1)
        {
            RaycastHit hit;
            // Construct a ray from the current touch coordinates
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            // Create a particle if hit
            if (Physics.Raycast(ray, out hit, 2000.0f))
            {
                if (hit.collider.transform.parent != c.transform)
                {
                    hit.collider.transform.parent = c.transform;
                    hit.collider.transform.position = hit.collider.transform.position + new Vector3(0, 0, -8);
                    Debug.Log("You selected " + hit.collider.transform.name); // ensure you picked right object

                }
                else
                {
                    hit.collider.transform.parent = null;
                    hit.collider.transform.position = hit.collider.transform.position + new Vector3(0, 0, 8);
                    Debug.Log("You unselected " + hit.collider.transform.name); // ensure you picked right object

                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 2000.0f))
            {
                if (hit.collider.transform.parent != c.transform)
                {
                    hit.collider.transform.parent = c.transform;
                    hit.collider.transform.position = hit.collider.transform.position + new Vector3(0, 0, -8);
                    Debug.Log("You selected " + hit.collider.transform.name); // ensure you picked right object

                }
                else
                {
                    hit.collider.transform.parent = null;
                    hit.collider.transform.position = hit.collider.transform.position + new Vector3(0, 0, 8);
                    Debug.Log("You unselected " + hit.collider.transform.name); // ensure you picked right object

                }
                //StartCoroutine(ScaleMe(hit.transform));
            }
        }
        }
    }

