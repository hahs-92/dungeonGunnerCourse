using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetAnimation(RuntimeAnimatorController animatorController, Color spriteColor)
    {
        animator.runtimeAnimatorController = animatorController;
        spriteRenderer.color = spriteColor;
    }
}
