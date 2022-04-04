using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]

public class Score : MonoBehaviour
{
    Text uiText;                                //UIText �R���|�[�l���g
    public int Points { get; private set; }     //���݂̃X�R�A�|�C���g
    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>();
    }
    public void AddScore(int addPoint)
    {
        //���݂̃|�C���g�ɉ��Z
        Points += addPoint;
        //���_�̍X�V
        uiText.text = string.Format("���_�F{0:D3}�_", Points);
    }
    
}
