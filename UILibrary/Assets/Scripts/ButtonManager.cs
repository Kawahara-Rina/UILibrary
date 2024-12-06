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
    [Header("スケールの最大値(拡大時)")]
    [Tooltip("0.0～1.0の値。0が小さい")]
    [Range(Common.MIN_SCALE, Common.MAX_SCALE)]
    #endregion
    [SerializeField] private float maxScale;

    #region - スケールの最小値
    [Header("スケールの最小値(縮小時)")]
    [Tooltip("0.0～1.0の値。0が小さい")]
    [Range(Common.MIN_SCALE, Common.MAX_SCALE)]
    #endregion
    [SerializeField] private float minScale;

    #region - アニメーションの速度
    [Header("アニメーションの速度")]
    [Tooltip("0.1～4.0の値。0が遅い")]
    [Range(Common.MIN_SAMPLES, Common.MAX_SAMPLES)]
    #endregion
    [SerializeField] private float samples;

    // スケールを変更する時のカウント
    private float scaleCnt;

    // ポインターがボタンに重なっているかどうかのフラグ
    private bool isPointerEnter;

    // スケールを変更する際に使用する新しいスケール値
    private Vector3 newScale;

    /// <summary>
    /// スケールを指定した値に変更する関数
    /// </summary>
    /// <param name="_scale">もとにするスケール</param>
    private void SetScale(float _scale)
    {
        // TODO アニメーションのブラッシュアップ

        // ボタンにカーソルが重なっている時
        if (isPointerEnter)
        {
            // スケールカウントを減算し、徐々に小さく
            if (scaleCnt > _scale)
            {
                scaleCnt -= samples * Time.deltaTime;
            }
            else
            {
                // スケールの最小値まで小さくなればカウントのリセット
                scaleCnt = minScale;
            }
        }
        // ボタンからカーソルが外れた時
        else
        {
            //スケールカウントを加算し、徐々に大きく
            if (scaleCnt < Common.MAX_SCALE)
            {
                scaleCnt += samples * Time.deltaTime;
            }
            else
            {
                // スケールの最大値まで大きくなればカウントのリセット
                scaleCnt = Common.MAX_SCALE;
            }
        }

        // 新しいスケール値をセット
        newScale.x = scaleCnt;
        newScale.y = scaleCnt;
        // 子オブジェクトのスケールを変更
        this.gameObject.transform.GetChild(0).localScale = newScale;
    }

    /// <summary>
    /// ボタンのサイズを小さくする処理
    /// ボタンにカーソルが重なっているときに呼び出し(PointerEnter)
    /// </summary>
    public void ReduceSize()
    {
        // ボタンにカーソルが重なっているためフラグをオン
        isPointerEnter = true;
    }

    /// <summary>
    /// ボタンのサイズを大きくする処理
    /// ボタンからカーソルが外れた時に呼び出し(PointerExit)
    /// </summary>
    public void IncreaseSize()
    {
        // ボタンからカーソルが外れたためフラグをオフ
        isPointerEnter = false;
    }

    /// <summary>
    /// 変数の初期化を行う関数
    /// </summary>
    private void Init()
    {
        // カウントの初期化
        scaleCnt = Common.MAX_SCALE;
        isPointerEnter = false;
        newScale = new Vector3(0, 0, 0);

        // 親のサイズの初期化
        transform.localScale = new Vector3(maxScale, maxScale, maxScale);

    }

    private void Awake()
    {
        // 初期化処理
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        // フラグの値によりスケールを変化
        if (isPointerEnter)
        {
            // スケールを小さく
            SetScale(minScale);
        }
        else
        {
            // スケールを大きく
            SetScale(maxScale);
        }
    }
}
