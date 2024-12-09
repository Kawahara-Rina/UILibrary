using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TapEffectManager : MonoBehaviour
{
    #region - 使用する画像を格納する配列
    [Header("使用する画像(アニメーション順)")]
    [Tooltip("2～5枚？")]
    #endregion
    [SerializeField] public Sprite[] sprites;

    #region - アニメーションの速度
    [Header("アニメーションの速度")]
    [Tooltip("0.1～4.0の値。4が遅い、0.1が早い")]
    [Range( Common.MAX_SAMPLES, Common.MIN_SAMPLES)]
    #endregion
    [SerializeField] public float samples;

    #region - タップエフェクトプレファブ
    [Header("プレファブ ”TapEffect”を格納")]
    [Tooltip("Assets/Resources/Prefabs/TapEffect")]
    #endregion
    [SerializeField] GameObject tapEffectPrefab;

    #region - タップエフェクトを表示するキャンバス
    [Header("タップエフェクトを表示するキャンバス")]
    //[Tooltip("Assets/Resources/Prefabs/TapEffect")]
    #endregion
    // 表示するキャンバス
    [SerializeField] Canvas canvas;

    // キャンバス内のレクトトランスフォーム取得用
    private RectTransform canvasRect;
    // ポインター(マウス)の位置
    private Vector2 mPos;

    // あらかじめオブジェクトを生成するためのリスト
    private List<GameObject> objList = new List<GameObject>();
    // リストの添え字を指定するためのカウント
    private int index;

    /// <summary>
    /// 初期化処理 
    /// </summary>
    private void Init()
    {
        // キャンバスのレクトトランスフォーム取得
        canvasRect = canvas.GetComponent<RectTransform>();

        // プレファブをリストに登録
        for (int i = 0; i < Common.GENERATE_COUNT; i++)
        {
            var tmp = Instantiate(tapEffectPrefab);
            tmp.gameObject.transform.SetParent(canvas.transform, false);

            objList.Add(tmp);
        }
    }

    /// <summary>
    // タップエフェクトの表示を行う関数
    /// </summary>
    private void ShowTapEffect()
    {
        // タップした場所を取得
        // キャンバスのレクトトランスフォーム内にあるマウスの位置をローカル座標に変換
        RectTransformUtility.ScreenPointToLocalPointInRectangle
            (canvasRect,
            Input.mousePosition,
            canvas.worldCamera,
            out mPos);

        // リストの中のオブジェクトを表示
        objList[index].gameObject.transform.localPosition = new Vector2(mPos.x,mPos.y);
        objList[index].gameObject.SetActive(true);

        // EffectAnimationコルーチンを開始
        StartCoroutine(objList[index].GetComponent<TapEffect>().EffectAnimation(
            sprites,
            samples * Common.MIN_SAMPLES));

        // 添え字をカウント
        if (index < Common.GENERATE_COUNT-1)
        {
            index++;
        }
        else
        {
            index = 0;
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
        if (Input.GetMouseButtonDown(0))
        {
            // タップした座標にタップエフェクトを表示
            ShowTapEffect();
        }

        if (Input.GetKey(KeyCode.A))
        {
            SceneManager.LoadScene("New Scene");
        }
    }
}
