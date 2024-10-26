using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State : MonoBehaviour
{
   public enum STATE {IDLE, PATROL, PURSUE, ATTACK, DEAD};
   public enum EVENT {ENTER, UPDATE, EXIT};
   public STATE state;
   public EVENT stage;
   protected GameObject npc;
   protected Animator anim;
   protected Transform player;
   protected State nextState;
   protected NavMeshAgent agent;
   float visionDIstance = 10.0f;
   float visionAngle = 30.0f;
   float attackDistance = 7.0f;

   public State (GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
   {
    npc = _npc;
    agent = _agent;
    anim = _anim;
    player = _player;
    stage = EVENT.ENTER;
   }

   public virtual void Enter() {stage = EVENT.UPDATE;}
   public virtual void Update() {stage = EVENT.UPDATE;}
   public virtual void Exit() {stage = EVENT.EXIT;}

   public State Process()
   {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT) Exit();
        {
            Exit();
            return nextState;
        }
        return this;
   }
}
