using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputCustom : MonoBehaviour
{
    public FixedJoystick joystick;
    [SerializeField] FixedButton jumpButton; 
    [SerializeField] FixedButton shootButton; 

    [HideInInspector]
    public bool jump = false;
    [HideInInspector]
    public bool shoot = false;
    [HideInInspector]
    public float horizontal;
    [HideInInspector]
    public float vertical;

    private void Update()
    {
        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;
        jump = jumpButton.isPressed;
        shoot = shootButton.isPressed;
    }

}
