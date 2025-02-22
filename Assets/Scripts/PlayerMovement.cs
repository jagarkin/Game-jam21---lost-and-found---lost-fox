﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Update is called once per frame
    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        // when right our move is + when left - so abs  to always be +
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
        if(Input.GetButtonDown("Jump")) {
            animator.SetBool("isJumping", true);
            jump = true;
            
        }

        if (Input.GetButtonDown("Crouch")) {
			crouch = true;
		} else if (Input.GetButtonUp("Crouch")) {
			crouch = false;
		}

    }

    public void OnLanding() {
        animator.SetBool("isJumping", false);
    }

    public void OnCrouching (bool isCrouching) {
		animator.SetBool("isCrouching", isCrouching);
	}

    void FixedUpdate() {
        // move player
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
