using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    [Tooltip("0.1～2.0の値。0が遅い")]
    [Range(Common.MIN_SAMPLES, Common.MAX_SAMPLES)]
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
    [SerializeField] GameObject canvas;
    

    // 初期化処理
    private void Init()
    {
    }

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        // タップエフェクトプレファブを生成
        var obj = Instantiate(tapEffectPrefab);
        obj.transform.SetParent(canvas.transform, false);

        //var tapEffect = tapEffectPrefab.GetComponent<TapEffect>();

        //StartCoroutine(tapEffect.EffectAnimation(sprites, samples,1.0f));

    }

    // Update is called once per frame
    void Update()
    {
    }
}
