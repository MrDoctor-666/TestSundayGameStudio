using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Vector3 rotateAmount;
    [SerializeField] List<Color> colorList;

    private int currentColor = 0;
    TouchPhase touchPhase = TouchPhase.Ended;

    private void Start()
    {
        GetComponent<Renderer>().material.color = colorList[currentColor];
    }

    void Update()
    {
        transform.Rotate(rotateAmount * Time.deltaTime);

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == touchPhase)
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;

            if (Physics.Raycast(raycast, out raycastHit))
            {
                GameObject touchedObject = raycastHit.collider.gameObject;
                Debug.Log("Touched " + touchedObject.transform.name);
                currentColor = (currentColor + 1) % colorList.Count;
                GetComponent<Renderer>().material.color = colorList[currentColor];

            }
        }
    }
}
