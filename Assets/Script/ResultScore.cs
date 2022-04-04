using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]

public class ResultScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�Q�[���I�u�W�F�N�g������
        var gameObj = GameObject.FindWithTag("Score");
        //gameObj�Ɋ܂܂��Score�R���|�[�l���g���擾
        var score = gameObj.GetComponent<Score>();
        //Text�R���|�[�l���g�̎擾
        var uiText = GetComponent<Text>();
        //���_�̍X�V
        uiText.text = string.Format("���_�F{0:D3}�_", score.Points);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
