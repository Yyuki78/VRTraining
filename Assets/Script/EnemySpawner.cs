using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy[] enemyPrefabs; //�o��������G�̃v���n�u

    Enemy enemy; //�o�����̓G��ێ�

    public void Spawn()
    {
        //�o�����łȂ���ΓG���o��������
        if (enemy == null)
        {
            //�o�^����Ă���G��Prefab����1�������_���őI��
            var index = Random.Range(0, enemyPrefabs.Length);

            //�I�񂾓G�̃C���X�^���X���쐬
            enemy = Instantiate(enemyPrefabs[index], transform.position, transform.rotation);
        }
    }
}
