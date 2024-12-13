using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideManager : MonoBehaviour
{
    // 定数
    private const float ADD_SPEED = 5000.0f;

    // スライドの方向を指定するための列挙体
    private enum FlowType
    {
        UpToBottom,
        BottomToUp,
        RightToLeft,
        LeftToRight
    };

    // スライドインかアウトを指定するための列挙体
    private enum SlideType
    {
        SlideIn,
        SlideOut
    };

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

    /// <summary>
    /// 移動処理(スライド)部分
    /// </summary>
    private void Slide()
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
                        pos.y -= Time.deltaTime * samples * ADD_SPEED;
                    }
                    else
                    {
                        pos.y = inStopPos;
                    }
                }
                else
                {
                    if (pos.y > outStopPos)
                    {
                        pos.y -= Time.deltaTime * samples * ADD_SPEED;
                    }
                    else
                    {
                        pos.y = outStopPos;
                    }
                }
                break;

            case FlowType.BottomToUp:

                if (slideType == SlideType.SlideIn)
                {
                    if (pos.y < inStopPos)
                    {
                        pos.y += Time.deltaTime * samples * ADD_SPEED;
                    }
                    else
                    {
                        pos.y = inStopPos;
                    }
                }
                else
                {
                    if (pos.y < outStopPos)
                    {
                        pos.y += Time.deltaTime * samples * ADD_SPEED;
                    }
                    else
                    {
                        pos.y = outStopPos;
                    }
                }
                break;

            case FlowType.RightToLeft:

                if (slideType == SlideType.SlideIn)
                {
                    if (pos.x > inStopPos)
                    {
                        pos.x -= Time.deltaTime * samples * ADD_SPEED;
                    }
                    else
                    {
                        pos.x = inStopPos;
                    }
                }
                else
                {
                    if (pos.x > outStopPos)
                    {
                        pos.x -= Time.deltaTime * samples * ADD_SPEED;
                    }
                    else
                    {
                        pos.x = outStopPos;
                    }
                }
                break;

            case FlowType.LeftToRight:

                if (slideType == SlideType.SlideIn)
                {
                    if (pos.x < inStopPos)
                    {
                        pos.x += Time.deltaTime * samples * ADD_SPEED;
                    }
                    else
                    {
                        pos.x = inStopPos;
                    }
                }
                else
                {
                    if (pos.x < outStopPos)
                    {
                        pos.x += Time.deltaTime * samples * ADD_SPEED;
                    }
                    else
                    {
                        pos.x = outStopPos;
                    }
                }
                break;
        }

        // 現在の座標を変更
        transform.localPosition = new Vector2(pos.x, pos.y);
    }

    // Update is called once per frame
    void Update()
    {
        // アニメーション再生時
        if (isShow)
        {
            // 移動処理実行
            Slide();
        }
    }
}
