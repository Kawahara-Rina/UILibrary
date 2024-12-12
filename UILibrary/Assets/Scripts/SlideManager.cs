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

    #region - スライド方向の指定
    [Header("スライド方向の指定")]
    [Tooltip("動的に制御したい場合は、任意のタイミングでこのフラグを切り替えてください。")]
    #endregion
    [SerializeField] public FlowType flowType = FlowType.UpToBottom;

    #region - 最初からアニメーションをするかどうか
    [Header("最初からアニメーションをするかどうか(true:する,false:しない)")]
    [Tooltip("最初から表示しない場合は、任意のタイミングでこのフラグをtrueにしてください。")]
    #endregion
    [SerializeField] public bool isShow = true;

    #region - スライド"イン"時の開始位置(ローカルポジション)
    [Header("スライド”イン”時の開始位置")]
    #endregion
    [SerializeField] private float startPos = 0;

    #region - スライド"イン"時の停止位置(ローカルポジション)
    [Header("スライド”イン”時の停止位置")]
    #endregion
    [SerializeField] private float stopPos = 1700f;

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

    // 現在の位置取得用
    private Vector2 pos;

    /// <summary>
    /// 上→下方向のスライドを実行する関数
    /// </summary>
    public void ShowUpToBottom()
    {
        transform.localPosition = new Vector2(pos.x, startPos);
        flowType = FlowType.UpToBottom;
        isShow = true;
    }

    /// <summary>
    /// 下→上方向のスライドを実行する関数
    /// </summary>
    public void ShowBottomToUp()
    {
        transform.localPosition = new Vector2(pos.x, startPos);
        flowType = FlowType.BottomToUp;
        isShow = true;
    }

    /// <summary>
    /// 右→左方向のスライドを実行する関数
    /// </summary>
    public void ShowRightToLeft()
    {
        transform.localPosition = new Vector2(startPos,pos.y);
        flowType = FlowType.RightToLeft;
        isShow = true;
    }

    /// <summary>
    /// 左→右方向のスライドを実行する関数
    /// </summary>
    public void ShowLeftToRight()
    {
        transform.localPosition = new Vector2(startPos, pos.y);
        flowType = FlowType.LeftToRight;
        isShow = true;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO 停止位置で止まらないのを修正
        // TODO 二回以上スライドしたいときの動作の修正
        if (isShow)
        {
            // 現在の座標を取得
            pos = transform.localPosition;

            // スライドの方向に応じて移動処理を変更
            switch (flowType)
            {
                case FlowType.UpToBottom:

                    if (pos.y > stopPos)
                    {
                        pos.y -= Time.deltaTime * samples * 3000.0f;
                    }
                    break;

                case FlowType.BottomToUp:
                    if (pos.y < stopPos)
                    {
                        pos.y += Time.deltaTime * samples*3000.0f ;
                    }
                    break;

                case FlowType.RightToLeft:

                    if (pos.x > stopPos)
                    {
                        pos.x -= Time.deltaTime * samples * 3000.0f;
                    }
                    break;

                case FlowType.LeftToRight:

                    if (pos.x < stopPos)
                    {
                        pos.x += Time.deltaTime * samples * 3000.0f;
                    }
                    break;
            }

            // 現在の座標を変更
            transform.localPosition = new Vector2(pos.x, pos.y);
        }
    }
}
