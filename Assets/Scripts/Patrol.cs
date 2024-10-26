using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : State
{
    int currentIndex = -1;

    public Patrol(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
    : base(_npc, _agent, _anim, _player)
    {
        state = STATE.PATROL;
        agent.speed = 2;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        Debug.Log("Entrando em PATROL");
        currentIndex = 0;
        anim.SetTrigger("isWalking");
        base.Enter();
    }

    public override void Update()
    {
        if(agent.remainingDistance < 1)
        {
            currentIndex =
                currentIndex >= GameEnviroment.Singleton.Checkpoints.Count - 1 ?
                0 :
                currentIndex + 1;

            agent.SetDestination(GameEnviroment.Singleton.Checkpoints
            [currentIndex].transform.position);
        }
    }

    public override void Exit()
    {
        Debug.Log("Saindo de PATROL");
        anim.ResetTrigger("isWalking");
        base.Exit();
    }
}
