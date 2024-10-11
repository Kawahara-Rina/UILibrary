/*
    PanelManager.cs
    2024/10/11  Kawahara Rina

    パネルのアニメーション処理を管理するクラス 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    // Animator取得用
    private Animator animator;

    // ズームするパネルのアクティブフラグをセットする関数
    public void SetBool(bool _flag)
    {
        // フラグがtrueの場合はパネルを表示する
        if (_flag)
            Common.SetActive(gameObject, _flag);

        // アニメーションのアクティブフラグセット
        animator.SetBool("isActive", _flag);
    }

    // 初期化処理
    // オブジェクトが非アクティブ状態でも実行したいのでAwake関数を使う
    private void Awake()
    {
        // Animator取得
        animator = GetComponent<Animator>();
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
