using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] InputCustom input;
    [SerializeField] Animator animator;


    private void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(input.vertical));
        animator.SetBool("jump", input.jump);
        animator.SetBool("shoot", input.shoot);
    }
}
