using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    // ���ʃR�[�h
    void Update()
    {
        transform.forward = GameObject.Find("Main Camera").GetComponent<Camera>().transform.forward;
    }

    // ���ʓs����A��L�ɂȂ��Ă��܂����A���L�R�����g�����̏������̕����������y���Ȃ�܂��B
    /*
        Camera mainCamera;        // ���C���J�����̕ێ�

        void Start()
        {
            // ���C���J�����̎擾
            mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        }

        void Update()
        {
            transform.forward = mainCamera.transform.forward;
        }
    */
}
