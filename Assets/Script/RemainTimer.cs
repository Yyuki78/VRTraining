using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class RemainTimer : MonoBehaviour
{
    [SerializeField] float gametime = 30.0f;  //�Q�[����������[s]
    Text uiText;    //UIText�@�R���|�[�l���g

    float currentTime; //�c�莞�ԃ^�C�}�[
    // Start is called before the first frame update
    void Start()
    {
        //Text�R���|�[�l���g�擾
        uiText = GetComponent<Text>();
        //�c�莞�Ԃ�ݒ�
        currentTime = gametime;
    }

    // Update is called once per frame
    void Update()
    {
        //�c�莞�Ԃ��v�Z
        currentTime -= Time.deltaTime;
        //0�b�ȉ��ɂ͂Ȃ�Ȃ�
        if (currentTime <= 0.0f)
        {
            currentTime = 0.0f;
        }
        //�c�莞�ԃe�L�X�g�X�V
        uiText.text = string.Format("�c�莞�ԁF{0:f}�b", currentTime);
    }
    //�J�E���g�_�E�����s���Ă��邩�H
    public bool IsCountingDown()
    {
        //�J�E���^�[��0�łȂ���΁A�J�E���g��
        return currentTime > 0.0f;
    }
}
