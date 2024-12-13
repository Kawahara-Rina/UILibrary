using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideManager : MonoBehaviour
{
    // フェードインかアウトかを指定するための列挙体
    public
        enum FlowType
    {
        UpToBottom,
        BottomToUp,
        RightToLeft,
        LeftToRight
    };

    public
        enum SlideType
    {
        SlideIn,
        SlideOut
    };

    /*
    #region - スライド方向の指定
    [Header("スライド方向の指定")]
    [Tooltip("動的に制御したい場合は、任意のタイミングでこのフラグを切り替えてください。")]
    #endregion
    [SerializeField] public FlowType flowType = FlowType.UpToBottom;
    */

    #region - スライド"イン"時の開始位置(ローカルポジション)
    [Header("スライド”イン”時の開始位置")]
    #endregion
    [SerializeField] private float inStartPos = 0;

    #region - スライド"イン"時の停止位置(ローカルポジション)
    [Header("スライド”イン”時の停止位置")]
    #endregion
    [SerializeField] private float inStopPos = 0;

    #region - スライド"アウト"時の開始位置(ローカルポジション)
    [Header("スライド”アウト”時の開始位置")]
    #endregion
    [SerializeField] private float outStartPos = 0;

    #region - スライド"アウト"時の停止位置(ローカルポジション)
    [Header("スライド”アウト”時の停止位置")]
    #endregion
    [SerializeField] private float outStopPos = 0;

    #region - アニメーションの速度
    [Header("アニメーションの速度")]
    [Tooltip("0.1～4.0の値。0が遅い")]
    [Range(Common.MIN_SAMPLES, Common.MAX_SAMPLES)]
    #endregion
    [SerializeField] private float samples = 1.0f;

    /*
    #region - 透明度の変化をつけるかどうかのフラグ
    [Header("透明度の変化をつけるかを指定(true:変化あり,false:変化なし)")]
    #endregion
    [SerializeField] public bool isChangeAlpha = false;

    #region - 透明度の最大値
    [Header("透明度の最大値(CanvasGroupの透明度)")]
    [Tooltip("0.0～1.0の値。0が小さい")]
    [Range(Common.MIN_ALPHA, Common.MAX_ALPHA)]
    #endregion
    [SerializeField] private float maxAlpha = 1.0f;

    #region - 透明度の最小値
    [Header("透明度の最小値(CanvasGroupの透明度)")]
    [Tooltip("0.0～1.0の値。0が小さい")]
    [Range(Common.MIN_ALPHA, Common.MAX_ALPHA)]
    #endregion
    [SerializeField] private float minAlpha = 0;
    */

    // スライド方向の指定用
    private FlowType flowType = FlowType.UpToBottom;

    // 現在の位置取得用
    private Vector2 pos;

    // スライドイン・アウトどちらかのフラグ
    private SlideType slideType;
    // アニメーションを再生するかどうか
    private bool isShow = false;

    /// <summary>
    /// スライドインしたいときに呼び出す関数
    /// </summary>
    public void SlideIn()
    {
        slideType = SlideType.SlideIn;
        isShow = true;
    }

    /// <summary>
    /// スライドアウトしたいときに呼び出す関数
    /// </summary>
    public void SlideOut()
    {
        slideType = SlideType.SlideOut;
        isShow = true;
    }

    /// <summary>
    /// 上→下方向のスライドを実行する関数
    /// </summary>
    public void ShowUpToBottom()
    {
        if (slideType == SlideType.SlideIn)
        {
            transform.localPosition = new Vector2(inStopPos, inStartPos);
        }
        else
        {
            transform.localPosition = new Vector2(pos.x, outStartPos);
        }

        flowType = FlowType.UpToBottom;
    }

    /// <summary>
    /// 下→上方向のスライドを実行する関数
    /// </summary>
    public void ShowBottomToUp()
    {
        if (slideType == SlideType.SlideIn)
        {
            transform.localPosition = new Vector2(pos.x, inStartPos);
        }
        else
        {
            transform.localPosition = new Vector2(pos.x, outStartPos);
        }

        flowType = FlowType.BottomToUp;
    }

    /// <summary>
    /// 右→左方向のスライドを実行する関数
    /// </summary>
    public void ShowRightToLeft()
    {
        if (slideType == SlideType.SlideIn)
        {
            transform.localPosition = new Vector2(inStartPos, outStartPos);
        }
        else
        {
            transform.localPosition = new Vector2(outStartPos, pos.y);
        }
        flowType = FlowType.RightToLeft;
    }

    /// <summary>
    /// 左→右方向のスライドを実行する関数
    /// </summary>
    public void ShowLeftToRight()
    {
        if (slideType == SlideType.SlideIn)
        {
            transform.localPosition = new Vector2(inStartPos, outStartPos);
        }
        else
        {
            transform.localPosition = new Vector2(outStartPos, pos.y);
        }
        flowType = FlowType.LeftToRight;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO 停止位置で止まらないのを修正
        if (isShow)
        {
            // 現在の座標を取得
            pos = transform.localPosition;

            // スライドの方向に応じて移動処理を変更
            switch (flowType)
            {
                case FlowType.UpToBottom:

                    if (slideType == SlideType.SlideIn)
                    {
                        if (pos.y > inStopPos)
                        {
                            pos.y -= Time.deltaTime * samples * 3000.0f;
                        }
                    }
                    else
                    {
                        if (pos.y > outStopPos)
                        {
                            pos.y -= Time.deltaTime * samples * 3000.0f;
                        }
                    }
                    break;

                case FlowType.BottomToUp:

                    if (slideType == SlideType.SlideIn)
                    {
                        if (pos.y < inStopPos)
                        {
                            pos.y += Time.deltaTime * samples * 3000.0f;
                        }
                    }
                    else
                    {
                        if (pos.y < outStopPos)
                        {
                            pos.y += Time.deltaTime * samples * 3000.0f;
                        }
                    }
                    break;

                case FlowType.RightToLeft:

                    if (slideType == SlideType.SlideIn)
                    {
                        if (pos.x > inStopPos)
                        {
                            pos.x -= Time.deltaTime * samples * 3000.0f;
                        }
                    }
                    else
                    {
                        if (pos.x > outStopPos)
                        {
                            pos.x -= Time.deltaTime * samples * 3000.0f;
                        }
                    }
                    break;

                case FlowType.LeftToRight:

                    if (slideType == SlideType.SlideIn)
                    {
                        if (pos.x < inStopPos)
                        {
                            pos.x += Time.deltaTime * samples * 3000.0f;
                        }
                    }
                    else
                    {
                        if (pos.x < outStopPos)
                        {
                            pos.x += Time.deltaTime * samples * 3000.0f;
                        }
                    }
                    break;
            }

            // 現在の座標を変更
            transform.localPosition = new Vector2(pos.x, pos.y);
        }
    }
}
