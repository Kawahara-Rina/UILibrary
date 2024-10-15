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
    #region - スケールの最大値
    [Header("スケールの最大値(拡大時)")][Tooltip("0.0～1.0の値。0が小さい")]
    [Range(Common.MIN_SCALE,Common.MAX_SCALE)]
    #endregion
    [SerializeField] private float maxScale;

    #region - スケールの最小値
    [Header("スケールの最小値(縮小時)")][Tooltip("0.0～1.0の値。0が小さい")]
    [Range(Common.MIN_SCALE, Common.MAX_SCALE)]
    #endregion
    [SerializeField] private float minScale;

    #region - アニメーションの速度
    [Header("アニメーションの速度")][Tooltip("0.0～1.0の値。0が小さい")]
    [Range(Common.MIN_SCALE, Common.MAX_SCALE)]
    #endregion
    [SerializeField] private float samples;

    // スケールを変更する関数
    /// <summary>
    /// スケールを指定した値に変更する関数
    /// </summary>
    /// <param name="_x">スケールのx成分</param>
    /// <param name="_y">スケールのy成分</param>
    private void SetScale(float _x,float _y)
    {
        // スケールを引数の値に変更
        var newScale=new Vector3(0,0,0);
        newScale.x =_x;
        newScale.y =_y;

        // 子オブジェクトのスケールを変更
        this.gameObject.transform.GetChild(0).localScale = newScale;
    }


    // サイズを小さくする
    public void ReduceSize()
    {
        // スケールを変更
        SetScale(minScale,minScale);
    }

    // サイズを元にもどす
    public void IncreaseSize()
    {
        // スケールを変更
        SetScale(maxScale, maxScale);
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
