using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveAgent : MonoBehaviour
{
    NavMeshAgent agent;  //�i�r���b�V���G�[�W�F���g
    
    void Start()
    {
        //�i�r���b�V���G�[�W�F���g���擾
        agent = GetComponent<NavMeshAgent>();

        //���̒n�_�ֈړ�
        GoToNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        //�ړI�n�ɓ����������ǂ����H
        if (agent.remainingDistance < 0.5f)
        {
            //���̒n�_�ֈړ�
            GoToNextPoint();
        }
    }

    void GoToNextPoint()
    {
        //���̈ړ��n�_�������_���ō쐬
        var nextPoint = new Vector3(Random.Range(-20.0f, 20.0f), 0.0f, Random.Range(-20.0f, 20.0f));

        //�i�r���b�V���G�[�W�F���g�֖ړI�n��ݒ�
        agent.SetDestination(nextPoint);
    }
}
