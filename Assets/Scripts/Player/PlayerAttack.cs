using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private string ANIMATION_ATTACK = "Attack";

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleButtonPressed();
    }

    void HandleButtonPressed()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetBool(ANIMATION_ATTACK, true);
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            anim.SetBool(ANIMATION_ATTACK, false);
        }
    }
}
