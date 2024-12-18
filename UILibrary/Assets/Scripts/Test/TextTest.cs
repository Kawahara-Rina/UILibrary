/*
    TextTest.cs
    2024/10/07  Kawahara Rina

    「Hellow World」を画面に表示するクラス
    パッケージ化して他プロジェクトでも使用できるかのテスト
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTest : MonoBehaviour
{
    // 使用するテキスト
    [SerializeField] private Text testText;  // 「Hellow World」を表示するテキスト 

    // 「Hellow World」を表示する関数
    // TODO Commonに移行
    /// <summary>
    /// テキストを表示する関数
    /// </summary>
    /// <param name="_msg"> 表示したい内容</param>
    /// <param name="_text">使用するテキスト</param>
    private void ShowText(string _msg,Text _text)
    {
        // 指定したテキストを表示
        _text.text = _msg;
    }

    // 初期化処理
    private void Init() {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        // 「Hellow World」を表示する
        ShowText("Hello World",testText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
