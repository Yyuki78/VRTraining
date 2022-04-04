using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;
using System.Linq;

public class PointerInputModule : BaseInputModule
{
    RaycastResultComparer comparer = new RaycastResultComparer();   // RaycastResult�f�[�^�̔�r����
    PointerEventData pointerData;       // �|�C���^�p�̃C�x���g�f�[�^
    List<RaycastResult> resultList;     // Raycast����
    Vector2 viewportCenter;             // ��ʒ��S�ʒu

    // RaycastResult�f�[�^�̔�r�����N���X
    class RaycastResultComparer : EqualityComparer<RaycastResult>
    {
        public override bool Equals(RaycastResult a, RaycastResult b)
        {
            return a.gameObject == b.gameObject;
        }

        public override int GetHashCode(RaycastResult r)
        {
            return r.gameObject.GetHashCode();
        }
    }

    protected override void Start()
    {
        // �C�x���g�f�[�^�̍쐬
        pointerData = new PointerEventData(eventSystem);
        // ��ʂ̒��S�ʒu��ݒ�
        viewportCenter = GetViewportCenter();
    }

    public override void Process()
    {
        // Raycast�̌��ʃf�[�^
        resultList = new List<RaycastResult>();

        // ��ʃZ���^�[�ʒu�ݒ�
        pointerData.Reset();
        pointerData.position = viewportCenter;

        // �J��������|�C���^�Ɍ�����Raycast���s��
        eventSystem.RaycastAll(pointerData, resultList);

        // �|�C���^�����̃t���[����UI�̗̈�ɂ͂��������̂𔲂��o���ă��X�g������
        var enterList = resultList.Except<RaycastResult>(m_RaycastResultCache, comparer);
        // �Ώۂ�UI�ɑ΂���PointerEnter�C�x���g�����s
        foreach (var r in enterList)
        {
            ExecuteEvents.Execute(r.gameObject, pointerData, ExecuteEvents.pointerEnterHandler);
        }

        // �|�C���^�����̃t���[����UI�̗̈悩��o�����̂𔲂��o���ă��X�g������
        var exitList = m_RaycastResultCache.Except<RaycastResult>(resultList, comparer);
        // �Ώۂ�UI�ɑ΂���PointerExit�C�x���g�����s
        foreach (var r in exitList)
        {
            ExecuteEvents.Execute(r.gameObject, pointerData, ExecuteEvents.pointerExitHandler);
        }

        // ����̌��ʂ�ۑ�
        m_RaycastResultCache = resultList;
    }

    // ��ʂ̒��S�ʒu���v�Z
    public Vector2 GetViewportCenter()
    {
        // ��ʂ̃T�C�Y
        var viewportWidth = Screen.width;
        var viewportHeight = Screen.height;

        // VR�Ō��Ă���Ƃ�
        if (XRSettings.enabled)
        {
            // �\���p�e�N�X�`���[�̃T�C�Y
            viewportWidth = XRSettings.eyeTextureWidth;
            viewportHeight = XRSettings.eyeTextureHeight;
        }

        // XY�T�C�Y�̔������A��ʂ̒��S�ʒu
        return new Vector2(viewportWidth * 0.5f, viewportHeight * 0.5f);
    }
}
/*
// Unity 2017.2�ȑO�̃\�[�X�R�[�h
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.VR;
using System.Linq;

public class PointerInputModule : BaseInputModule
{
    RaycastResultComparer comparer = new RaycastResultComparer();   // RaycastResult�f�[�^�̔�r����
    PointerEventData pointerData;       // �|�C���^�p�̃C�x���g�f�[�^
    List<RaycastResult> resultList;     // Raycast����
    Vector2 viewportCenter;             // ��ʒ��S�ʒu

    // RaycastResult�f�[�^�̔�r�����N���X
    class RaycastResultComparer : EqualityComparer<RaycastResult>
    {
        public override bool Equals(RaycastResult a, RaycastResult b)
        {
            return a.gameObject == b.gameObject;
        }

        public override int GetHashCode(RaycastResult r)
        {
            return r.gameObject.GetHashCode();
        }
    }

    protected override void Start()
    {
        // �C�x���g�f�[�^�̍쐬
        pointerData = new PointerEventData(eventSystem);
        // ��ʂ̒��S�ʒu��ݒ�
        viewportCenter = GetViewportCenter();
    }

    public override void Process()
    {
        // Raycast�̌��ʃf�[�^
        resultList = new List<RaycastResult>();

        // ��ʃZ���^�[�ʒu�ݒ�
        pointerData.Reset();
        pointerData.position = viewportCenter;

        // �J��������|�C���^�Ɍ�����Raycast���s��
        eventSystem.RaycastAll(pointerData, resultList);

        // �|�C���^�����̃t���[����UI�̗̈�ɂ͂��������̂𔲂��o���ă��X�g������
        var enterList = resultList.Except<RaycastResult>(m_RaycastResultCache, comparer);
        // �Ώۂ�UI�ɑ΂���PointerEnter�C�x���g�����s
        foreach (var r in enterList)
        {
            ExecuteEvents.Execute(r.gameObject, pointerData, ExecuteEvents.pointerEnterHandler);
        }

        // �|�C���^�����̃t���[����UI�̗̈悩��o�����̂𔲂��o���ă��X�g������
        var exitList = m_RaycastResultCache.Except<RaycastResult>(resultList, comparer);
        // �Ώۂ�UI�ɑ΂���PointerExit�C�x���g�����s
        foreach (var r in exitList)
        {
            ExecuteEvents.Execute(r.gameObject, pointerData, ExecuteEvents.pointerExitHandler);
        }

        // ����̌��ʂ�ۑ�
        m_RaycastResultCache = resultList;
    }

    // ��ʂ̒��S�ʒu���v�Z
    public Vector2 GetViewportCenter()
    {
        // ��ʂ̃T�C�Y
        var viewportWidth = Screen.width;
        var viewportHeight = Screen.height;

        // VR�Ō��Ă���Ƃ�
        if (VRSettings.enabled)
        {
            // �\���p�e�N�X�`���[�̃T�C�Y
            viewportWidth = VRSettings.eyeTextureWidth;
            viewportHeight = VRSettings.eyeTextureHeight;
        }

        // XY�T�C�Y�̔������A��ʂ̒��S�ʒu
        return new Vector2(viewportWidth * 0.5f, viewportHeight * 0.5f);
    }
}     
*/
