using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�ŏ��Ɉ�x���b�Z�[�W��\������
        Debug.Log("[Start]");
    }

    // Update is called once per frame
    void Update()
    {
        //Space�L�[��������Ă���ԃ��b�Z�[�W��\������
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("[Update] Space key pressed");
        }
    }
}
