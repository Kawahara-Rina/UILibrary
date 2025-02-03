/*
    DialogClose.cs

    ダイアログ以外の部分をタップでダイアログを閉じる機能
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogClose : MonoBehaviour
{
    private DialogCloseManager dm;

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Init()
    {
        dm = GameObject.Find("DialogCloseManager").GetComponent<DialogCloseManager>();
    }

    /// <summary>
    /// ダイアログを閉じる処理
    /// </summary>
    private void Close()
    {
        if (dm.isClose)
        {
            // 非表示処理
            this.gameObject.SetActive(false);
            //dm.FlagReset();
        }
    }


    private void Awake()
    {
        // 初期化処理
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        // ダイアログを閉じる処理
        Close();
    }
}
