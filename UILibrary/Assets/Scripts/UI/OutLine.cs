using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(Text))]
public class OutLine : BaseMeshEffect
{
    public Color outlineColor = Color.black; // アウトラインの色
    public float outlineWidth = 1f;         // アウトラインの幅

    public override void ModifyMesh(VertexHelper vh)
    {
        if (!IsActive() || vh.currentVertCount == 0)
            return;

        // オリジナルの頂点データを取得
        List<UIVertex> originalVertices = new List<UIVertex>();
        vh.GetUIVertexStream(originalVertices);

        int originalVertexCount = originalVertices.Count;
        List<UIVertex> modifiedVertices = new List<UIVertex>();

        // 8方向にアウトラインを生成
        Vector2[] directions = {
            new Vector2(-1, -1), new Vector2(-1,  1),
            new Vector2( 1, -1), new Vector2( 1,  1),
            new Vector2(-1,  0), new Vector2( 1,  0),
            new Vector2( 0, -1), new Vector2( 0,  1)
        };

        foreach (var dir in directions)
        {
            for (int i = 0; i < originalVertexCount; i++)
            {
                UIVertex vertex = originalVertices[i];
                vertex.position += new Vector3(dir.x * outlineWidth, dir.y * outlineWidth);
                vertex.color = outlineColor;
                modifiedVertices.Add(vertex);
            }
        }

        // 元の頂点データを追加
        modifiedVertices.AddRange(originalVertices);

        // 更新された頂点データを反映
        vh.Clear();
        vh.AddUIVertexTriangleStream(modifiedVertices);
    }
}