using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(Text))]
public class OutLine : BaseMeshEffect
{
    public Color outlineColor = Color.black; // �A�E�g���C���̐F
    public float outlineWidth = 1f;         // �A�E�g���C���̕�

    public override void ModifyMesh(VertexHelper vh)
    {
        if (!IsActive() || vh.currentVertCount == 0)
            return;

        // �I���W�i���̒��_�f�[�^���擾
        List<UIVertex> originalVertices = new List<UIVertex>();
        vh.GetUIVertexStream(originalVertices);

        int originalVertexCount = originalVertices.Count;
        List<UIVertex> modifiedVertices = new List<UIVertex>();

        // 8�����ɃA�E�g���C���𐶐�
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

        // ���̒��_�f�[�^��ǉ�
        modifiedVertices.AddRange(originalVertices);

        // �X�V���ꂽ���_�f�[�^�𔽉f
        vh.Clear();
        vh.AddUIVertexTriangleStream(modifiedVertices);
    }
}