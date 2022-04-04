using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 20f; //�e��[m/s]

    [SerializeField] ParticleSystem hitParticlePrefab;//���e�����o�v���n�u

    // Start is called before the first frame update
    void Start()
    {
        //�Q�[���I�u�W�F�N�g�O�����̑��x�x�N�g�����v�Z
        var velocity = speed * transform.forward;

        //Rigidbody�R���|�[�l���g���擾
        var rigidbody = GetComponent<Rigidbody>();

        //Rigidbody�R���|�[�l���g���g���ď�����^����
        rigidbody.AddForce(velocity, ForceMode.VelocityChange);
    }

    //�g���K�[�̈�i�����ɌĂяo�����
    private void OnTriggerEnter(Collider other)
    {
        //�ՓˑΏۂ�"OnHitBullet"���b�Z�[�W
        other.SendMessage("OnHitBullet");

        //���e���ɉ��o�����Đ��̃Q�[���I�u�W�F�N�g�𐶐�
        Instantiate(hitParticlePrefab, transform.position, transform.rotation);

        //���g�̃Q�[���I�u�W�F�N�g��j��
        Destroy(gameObject);
    }
}
