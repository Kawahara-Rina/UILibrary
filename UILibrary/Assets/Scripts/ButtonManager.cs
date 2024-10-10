/*
    ButtonManager.cs
    2024/10/09  Kawahara Rina

    ボタンのアニメーションを制御するクラス
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    // アニメーター取得用
    private Animator animator;

    // レクトトランスフォーム取得用
    private Vector2 rTransform;

    private float width;    // ボタンの幅  
    private float height;   // ボタンの高さ

    // フラグをセットする関数
    public void SetPointerEnterBool(bool _flag)
    {
        animator.SetBool("isPointerEnter", _flag);
    }

    // サイズを小さくする
    private void ReduceSize()
    {
        rTransform.x =width*0.8f;
        rTransform.y = height*0.8f;

        GetComponent<RectTransform>().sizeDelta = rTransform;

    }

    // サイズを元にもどす
    private void IncreaseSize()
    {
        rTransform.x = width;
        rTransform.y = height;

        GetComponent<RectTransform>().sizeDelta = rTransform;

    }

    // Start is called before the first frame update
    void Start()
    {
        // アニメーター取得
        animator = GetComponent<Animator>();

        // レクトトランスフォーム取得
        rTransform = GetComponent<RectTransform>().sizeDelta;

        // ボタンの幅と高さ取得
        width = rTransform.x;
        height = rTransform.y;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
