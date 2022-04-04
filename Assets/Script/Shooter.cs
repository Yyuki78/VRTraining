using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab; //�e�̃v���n�u
    [SerializeField] Transform gunBarrelEnd;  //�e��(�e�̔��ˈʒu)

    [SerializeField] ParticleSystem gunParticle;//���ˎ����o
    [SerializeField] AudioSource gunAudioSource;//���ˎ��̉���
    
    void Update()
    {
        //���͂ɉ����Ēe�𔭎˂���
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //�v���n�u�����ɁA�V�[����ɒe�𐶐�
        Instantiate(bulletPrefab, gunBarrelEnd.position, gunBarrelEnd.rotation);

        //���ˎ����o���Đ�
        gunParticle.Play();

        //���ˎ��̉����Đ�
        gunAudioSource.Play();
    }
}
