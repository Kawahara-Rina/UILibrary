/*
    DialogCloseManager.cs

    ダイアログを閉じるかを検知するマネージャー
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCloseManager : MonoBehaviour
{
    // 定数
    private const int GAMEOBJECT_PANEL = 1;

    // ダイアログを閉じるかどうかのフラグ
    public bool isClose;

    // 子オブジェクト(パネル)取得
    private GameObject child;

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Init()
    {
        isClose = false;

        // 子オブジェクト(パネル)取得
        child = gameObject.transform.GetChild(GAMEOBJECT_PANEL).gameObject;
    }

    /// <summary>
    /// ダイアログを閉じるタイミングで呼ばれる関数
    /// </summary>
    public void CloseDialog()
    {
        isClose = true;
    }

    /// <summary>
    /// パネル等を非表示にする処理
    /// </summary>
    private void PanelAnActive()
    {
        child.SetActive(false);
        this.gameObject.SetActive(false);
        isClose = false;
    }

    /// <summary>
    /// パネル等を表示する処理
    /// </summary>
    public void PanelActive()
    {
        isClose = false;
        this.gameObject.SetActive(true);
        child.SetActive(true);

    }

    private void Awake()
    {
        // 初期化処理
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (isClose)
        {
            PanelAnActive();
        }
    }
}
