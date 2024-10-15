/*
    Common.cs
    2024/10/11　Kawahara Rina

    複数のスクリプトから使用する定数や汎用関数などをまとめたクラス
*/using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Common
{
    // 共通定数
    public const float MAX_SCALE = 1.0f;
    public const float MIN_SCALE = 0.0f;

    /*
    // 列挙体シリアライズするとインスペクタからリストで選べる
    [SerializeField] test testa;

    enum test
    {
        a,
        b
    }

    // Header：インスペクタに変数の説明出てくる
    // Tooltip：変数にカーソル合わせた時に変数の説明出てくる
    
    [Header("コメント")]
    [SerializeField] private GameObject a;

    [Header("bbb")]
    [SerializeField] private GameObject b;

    [Tooltip("bbb")]
    [SerializeField] private GameObject b;
    */



    /// <summary>
    /// オブジェクトをアクティブ・非アクティブにする関数
    /// </summary>
    /// <param name="_gameObject">アクティブ・非アクティブにするオブジェクト</param>
    /// <param name="_bool">アクティブか非アクティブかのブール値</param>
    public static void SetActive(GameObject _gameObject,bool _bool)
    {
        _gameObject.SetActive(_bool);
    }

    /// <summary>
    /// テキストを表示する関数
    /// </summary>
    /// <param name="_msg"> 表示したい内容</param>
    /// <param name="_text">使用するテキスト</param>
    private void ShowText(string _msg, Text _text)
    {
        // 指定したテキストを表示
        _text.text = _msg;
    }

    // 遅延処理関数
    /*
    public static IEnumerator WaitForSecond(float _sec)
    {
        // 指定した秒数待つ
        yield return new WaitForSeconds(_sec);
    }
    */
}
