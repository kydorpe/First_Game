using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;


    private object transformer;

    private void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        OnMove(); 
        OnRun();
    }


    #region Movement
    private void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if (player.isRoling)
            {
                anim.SetTrigger("IsRoll");
            }
            else
            {

                anim.SetInteger("Transition", 1);
            }
        }
        else
        {
            anim.SetInteger("Transition", 0);
        }

        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

   void OnRun()

    {
        if (player.isRunning)
        {
            anim.SetInteger("Transition", 2);
        }
    }


    #endregion
}

