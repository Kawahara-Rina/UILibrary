/*
    OutLine.cs

    �A�E�g���C�������N���X
*/
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
[RequireComponent(typeof(Text))]
public class OutLine : BaseMeshEffect
{
    #region - �A�E�g���C���̐F
    [Header("�A�E�g���C���̐F")]
    #endregion
    [SerializeField] Color color = Color.white;

    #region - �A�E�g���C���̑���
    [Header("�A�E�g���C���̑���")]
    [Tooltip("0,0�`10.0�̒l�B0���ׂ��A10�������B")]
    [Range(Common.MIN_THICKNESS, Common.MAX_THICKNESS)]
    #endregion
    [SerializeField] float thickness = 3.0f; 

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
                vertex.position += new Vector3(dir.x * thickness, dir.y * thickness);
                vertex.color = color;
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