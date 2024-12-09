using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapEffectManager : MonoBehaviour
{
    #region - �g�p����摜���i�[����z��
    [Header("�g�p����摜(�A�j���[�V������)")]
    [Tooltip("2�`5���H")]
    #endregion
    [SerializeField] public Sprite[] sprites;

    #region - �A�j���[�V�����̑��x
    [Header("�A�j���[�V�����̑��x")]
    [Tooltip("0.1�`4.0�̒l�B4���x���A0.1������")]
    [Range( Common.MAX_SAMPLES, Common.MIN_SAMPLES)]
    #endregion
    [SerializeField] public float samples;

    #region - �^�b�v�G�t�F�N�g�v���t�@�u
    [Header("�v���t�@�u �hTapEffect�h���i�[")]
    [Tooltip("Assets/Resources/Prefabs/TapEffect")]
    #endregion
    [SerializeField] GameObject tapEffectPrefab;

    #region - �^�b�v�G�t�F�N�g��\������L�����o�X
    [Header("�^�b�v�G�t�F�N�g��\������L�����o�X")]
    //[Tooltip("Assets/Resources/Prefabs/TapEffect")]
    #endregion
    // �\������L�����o�X
    [SerializeField] Canvas canvas;

    // �L�����o�X���̃��N�g�g�����X�t�H�[���擾�p
    private RectTransform canvasRect;
    // �|�C���^�[(�}�E�X)�̈ʒu
    private Vector2 mPos;

    /// <summary>
    /// ���������� 
    /// </summary>
    private void Init()
    {
        // �L�����o�X�̃��N�g�g�����X�t�H�[���擾
        canvasRect = canvas.GetComponent<RectTransform>();
    }

    // �^�b�v�G�t�F�N�g�̕\�����s���֐�
    private void ShowTapEffect()
    {
        // �^�b�v�����ꏊ���擾
        // �L�����o�X�̃��N�g�g�����X�t�H�[�����ɂ���}�E�X�̈ʒu�����[�J�����W�ɕϊ�
        RectTransformUtility.ScreenPointToLocalPointInRectangle
            (canvasRect,
            Input.mousePosition,
            canvas.worldCamera,
            out mPos);

        // �^�b�v�G�t�F�N�g�v���t�@�u�𐶐�
        var obj = Instantiate(tapEffectPrefab, new Vector3(mPos.x, mPos.y, 0), Quaternion.identity);
        obj.transform.SetParent(canvas.transform, false);

    }

    private void Awake()
    {
        // ����������
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // �^�b�v�������W�Ƀ^�b�v�G�t�F�N�g��\��
            ShowTapEffect();
        }
    }
}
