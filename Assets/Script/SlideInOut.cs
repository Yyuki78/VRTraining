using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(RectTransform))]
public class SlideInOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //rectTransformコンポーネントを取得
        var rectTransform = GetComponent<RectTransform>();

        //DOTweenのシーケンスを作成
        var sequence = DOTween.Sequence();

        //画面右からスライドインさせる
        sequence.Append(rectTransform.DOMoveX(0.0f, 1.0f));

        //画面左へスライドアウトさせる
        sequence.Append(rectTransform.DOMoveX(-1400.0f, 0.8f));
    }
}
