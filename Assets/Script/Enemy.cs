using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{
    [SerializeField] AudioClip spawnClip;//�o������AudioClip
    [SerializeField] AudioClip hitClip;   //�e��������AudioClip

    //�|���ꂽ�ۂɖ��������邽�߂ɃR���C�_�[�ƃ����_���[�������Ă���
    [SerializeField] Collider enemyCollider;//�R���C�_�[
    [SerializeField] Renderer enemyRenderer;//�����_���[

    AudioSource audioSource;//�Đ��Ɏg�p����AudioSource

    [SerializeField] int point = 1;
    Score score;

    [SerializeField] int hp = 1;  //�G�̃q�b�g�|�C���g

    [SerializeField] GameObject popupTextPrefab;   //���_�\���pPrefab

    private void Start()
    {
        //AudioSource�R���|�[�l���g���擾���Ă���
        audioSource = GetComponent<AudioSource>();

        //�o�����̉����Đ�
        audioSource.PlayOneShot(spawnClip);

        //�Q�[���I�u�W�F�N�g������
        var gameObj = GameObject.FindWithTag("Score");

        //gameObj�Ɋ܂܂��Score�R���|�[�l���g���擾
        score = gameObj.GetComponent<Score>();
    }

    // OnHitBullet���b�Z�[�W����Ăяo����邱�Ƃ�z��
    void OnHitBullet()
    {
        //�e�������̉����Đ�
        audioSource.PlayOneShot(hitClip);

        //HP���Z
        --hp;

        //HP��0�ɂȂ����玀�S
        if (hp <= 0)
        {
            //���S������
            GoDown();
        }
    }

    //���S������
    void GoDown()
    {
        //�X�R�A�����Z
        score.AddScore(point);

        //�|�b�v�A�b�v�e�L�X�g�̍쐬
        CreatePopupText();

        //�����蔻��ƕ\��������
        enemyCollider.enabled = false;
        enemyRenderer.enabled = false;

        //���g�̃Q�[���I�u�W�F�N�g����莞�Ԍ�ɔj��
        Destroy(gameObject, 1f);
    }

    //�|�b�v�A�b�v�e�L�X�g�̍쐬
    void CreatePopupText()
    {
        //�|�b�v�A�b�v�e�L�X�g�̃C���X�^���g�쐬
        var text = Instantiate(popupTextPrefab, transform.position, Quaternion.identity);

        //�|�b�v�A�b�v�e�L�X�g�̃e�L�X�g�ύX
        text.GetComponent<TextMesh>().text = string.Format("+{0}", point);
    }
}
