using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] float spawnInterval = 3f; //�G�o���Ԋu

    EnemySpawner[] spawners;//EnemySpawner�̃��X�g
    float timer = 0f;       //�o�����Ԕ���p�̃^�C�}�[�ϐ�

    // Start is called before the first frame update
    void Start()
    {
        //�q�I�u�W�F�N�g�ɑ��݂���EnemySpawner�̃��X�g���擾
        spawners = GetComponentsInChildren<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        //�^�C�}�[�X�V
        timer += Time.deltaTime;

        //�o���Ԋu�̔���
        if (spawnInterval < timer)
        {
            //�����_����EnemySpawner��I�����ēG���o��������
            var index = Random.Range(0, spawners.Length);
            spawners[index].Spawn();

            //�^�C�}�[���Z�b�g
            timer = 0f;
        }
    }
}
