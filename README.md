## ボタンアニメーション
- カーソルを合わせた時に縮小・離れた時に拡大するアニメーション
- ソース : **ButtonAnimation.cs**
- プレファブ : **ButtonPrefab**

### 使用時の注意点
1. **Buttonプレファブの構造について**<br>
- 拡大縮小時のちらつきを防ぐため、Buttonプレファブは親子構造になっています。
  ![alt text](Button①.png)

  ※ 親でButtonAnimation.csや、イベントトリガーの設定を行います。<br>
  ※ 子で画像の設定を行います。
<br>
<br>

2. **サイズ設定について**
- ボタンのサイズを変更したい場合はscaleではなくWidthとHeightで調整してください。<br>(Scaleは固定)
- 親と子のWidthとHeightの値は必ず一致させてください。
![alt text](Button②.png)
<br>
<br>

3. **maxScale、minScaleについて**
- 拡大縮小の値は、必ず<br>**maxScale > minScale** になるように設定してください。

### インスペクタ上で指定する変数について

| 変数名 | 型 | 用途 | 備考 |
| ---| ---| ---| --- |
| maxScale | float | スケールの最大値(拡大時) | 0~1.0の値 |
| minScale | float | スケールの最小値(縮小時) | 0~1.0の値 |
| samples | float | アニメーションの速度 | 0.1~4.0の値<br>0.1が遅い、4.0が速い |

### 使用するにあたって必要な物
| 必要な物 | アタッチ先 | 備考 |
| ---| ---| ---|
| Buttonプレファブ | - | Image等Button以外でも使用可能。 |
| ButtonAnimation.cs | Buttonプレファブの親オブジェクト(Button) | - |
| ボタンの画像 | Buttonプレファブの子オブジェクト(Image)の<br>Imageコンポーネント内 Source Image | - |