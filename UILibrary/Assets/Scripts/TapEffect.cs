using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapEffect : MonoBehaviour
{

    // スプライト配列の添え字指定用
    private int spritesNum;

    // タップエフェクトマネージャー取得
    private TapEffectManager tapEffectManager;

    public IEnumerator EffectAnimation(Sprite[] _sprites, float _samples, float _sec)
    {
        // 指定した秒数待つ
        yield return new WaitForSeconds(_sec);

        // スプライトが格納されている配列の添え字を変更
        if (spritesNum < _sprites.Length - 1)
        {
            spritesNum++;
        }
        else
        {
            // 添え字のリセット
            spritesNum = 0;
            // オブジェクトを削除
            Destroy(gameObject);

            // 処理終わりたいときは yield break
            yield break;
        }

        // スプライトを変更しアニメーション
        this.gameObject.GetComponent<Image>().sprite = _sprites[spritesNum];

        // 待った後にもう一度呼ぶ　再帰する
        StartCoroutine(EffectAnimation(_sprites, _samples, _sec));
    }



    // Start is called before the first frame update
    void Start()
    {
        tapEffectManager =GameObject.Find("TapEffectManager").GetComponent<TapEffectManager>();

        StartCoroutine(EffectAnimation(tapEffectManager.sprites, tapEffectManager.samples,1.0f));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
