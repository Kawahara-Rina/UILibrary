using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAnimation : MonoBehaviour
{
    // フェードインかアウトかを指定するための列挙体
    public
        enum FadeType
    {
        fadeIn,
        fadeOut
    };

    #region - フェードイン・アウトの指定
    [Header("フェードイン・アウトの指定")]
    [Tooltip("動的に制御したい場合は、任意のタイミングでこのフラグを切り替えてください。")]
    #endregion
    [SerializeField] public FadeType fadeType = FadeType.fadeIn;
    
    #region - 最初からアニメーションをするかどうか
    [Header("最初からアニメーションをするかどうか(true:する,false:しない)")]
    [Tooltip("最初から表示しない場合は、任意のタイミングでこのフラグをtrueにしてください。")]
    #endregion
    [SerializeField] public bool isShow = true;

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

    #region - アニメーションの速度
    [Header("アニメーションの速度")]
    [Tooltip("0.1～4.0の値。0が遅い")]
    [Range(Common.MIN_SAMPLES, Common.MAX_SAMPLES)]
    #endregion
    [SerializeField] private float samples=1.0f;

    // 初期透明度指定を一度だけ行うためのフラグ
    private bool isFirst;

    /// <summary>
    /// フェードインを行うタイミングで呼び出す関数
    /// </summary>
    public void ShowFadeIn()
    {
        fadeType = FadeType.fadeIn;
        isShow = true;
    }

    /// <summary>
    /// フェードアウトを行うタイミングで呼び出す関数
    /// </summary>
    public void ShowFadeOut()
    {
        fadeType = FadeType.fadeOut;
        isShow = true;
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Init()
    {
        isFirst = true;
    }

    /// <summary>
    /// 使用用途に応じて初期の透明度を指定する関数
    /// </summary>
    private void SetAlpha()
    {
        if (isFirst)
        {
            if (fadeType==FadeType.fadeIn)
            {
                // フェードイン→黒から透明に変化するため、アルファ値は1.0
                GetComponent<CanvasGroup>().alpha = 1.0f;
            }
            else
            {
                // フェードアウト→透明から黒に変化するため、アルファ値は0
                GetComponent<CanvasGroup>().alpha = 0.0f;
            }

            isFirst = false;
        }
    }

    /// <summary>
    /// フェードイン・アウトの処理
    /// </summary>
    private void Fade()
    {
        // フェードイン
        if (fadeType == FadeType.fadeIn)
        {
            if (GetComponent<CanvasGroup>().alpha > minAlpha)
            {
                GetComponent<CanvasGroup>().alpha -= Time.deltaTime * samples;
            }

        }
        // フェードアウト
        else
        {
            if (GetComponent<CanvasGroup>().alpha < maxAlpha)
            {
                GetComponent<CanvasGroup>().alpha += Time.deltaTime * samples;
            }

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
        // 演出開始でフェードイン・アウト
        if (isShow)
        {
            // 初期の透明度を設定
            SetAlpha();

            // フェード処理
            Fade();
        }

    }
}
