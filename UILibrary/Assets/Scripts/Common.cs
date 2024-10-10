using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common
{
    // オブジェクトをアクティブ・非アクティブにする関数
    public static void SetActive(GameObject _gameObject,bool _bool)
    {
        _gameObject.SetActive(_bool);
    }

    // 遅延処理関数
    public static IEnumerator WaitForSecond(float _sec)
    {
        // 指定した秒数待つ
        yield return new WaitForSeconds(_sec);
    }

}
