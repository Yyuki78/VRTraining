using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        //�w�肳�ꂽ�V�[�������[�h����
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        //�A�v���P�[�V�����̏I��
        Application.Quit();
    }

    public void ReloadScene()
    {
        //���݂̃V�[�����擾
        var scene = SceneManager.GetActiveScene();
        //���݂̃V�[�����ă��[�h����
        SceneManager.LoadScene(scene.name);
    }
}
