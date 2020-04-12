﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : BasicFSM<Enemy> {
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        /* ============================================== */
        if (ob.eye.see<Player>()) {
            Debug.Log("I See You");
            ob.player = ob.eye.see<Player>();
        }
    }
}