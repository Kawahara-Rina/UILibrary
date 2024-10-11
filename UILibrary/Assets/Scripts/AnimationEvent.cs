/*
    AnimationEvent.cs
    2024/10/10  Kawahara Rina

    アニメーション中に呼び出す処理や関数をまとめたクラス
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    /// <summary>
    /// オブジェクトを表示する
    /// </summary>
    private void ObjectActive()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// オブジェクトを非表示にする
    /// </summary>
    private void ObjectAnActive()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
