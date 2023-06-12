using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float rotationSpeed = 100f;

    private CharacterController controller;
    private InputCustom input;
    private Camera cam;



    void Start()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<InputCustom>();
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(input.horizontal, 0, input.vertical);
        move = transform.TransformDirection(move);
        controller.Move(move * Time.deltaTime * speed);
        transform.RotateAround(transform.position, transform.up, input.horizontal * Time.deltaTime * rotationSpeed);
    }
}
