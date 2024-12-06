/*
    ButtonManager.cs
    2024/10/09  Kawahara Rina

    �{�^���̃A�j���[�V�����𐧌䂷��N���X
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    #region - �X�P�[���̍ő�l
    [Header("�X�P�[���̍ő�l(�g�厞)")]
    [Tooltip("0.0�`1.0�̒l�B0��������")]
    [Range(Common.MIN_SCALE, Common.MAX_SCALE)]
    #endregion
    [SerializeField] private float maxScale;

    #region - �X�P�[���̍ŏ��l
    [Header("�X�P�[���̍ŏ��l(�k����)")]
    [Tooltip("0.0�`1.0�̒l�B0��������")]
    [Range(Common.MIN_SCALE, Common.MAX_SCALE)]
    #endregion
    [SerializeField] private float minScale;

    #region - �A�j���[�V�����̑��x
    [Header("�A�j���[�V�����̑��x")]
    [Tooltip("0.1�`4.0�̒l�B0���x��")]
    [Range(Common.MIN_SAMPLES, Common.MAX_SAMPLES)]
    #endregion
    [SerializeField] private float samples;

    // �X�P�[����ύX���鎞�̃J�E���g
    private float scaleCnt;

    // �|�C���^�[���{�^���ɏd�Ȃ��Ă��邩�ǂ����̃t���O
    private bool isPointerEnter;

    // �X�P�[����ύX����ۂɎg�p����V�����X�P�[���l
    private Vector3 newScale;

    /// <summary>
    /// �X�P�[�����w�肵���l�ɕύX����֐�
    /// </summary>
    /// <param name="_scale">���Ƃɂ���X�P�[��</param>
    private void SetScale(float _scale)
    {
        // TODO �A�j���[�V�����̃u���b�V���A�b�v

        // �{�^���ɃJ�[�\�����d�Ȃ��Ă��鎞
        if (isPointerEnter)
        {
            // �X�P�[���J�E���g�����Z���A���X�ɏ�����
            if (scaleCnt > _scale)
            {
                scaleCnt -= samples * Time.deltaTime;
            }
            else
            {
                // �X�P�[���̍ŏ��l�܂ŏ������Ȃ�΃J�E���g�̃��Z�b�g
                scaleCnt = minScale;
            }
        }
        // �{�^������J�[�\�����O�ꂽ��
        else
        {
            //�X�P�[���J�E���g�����Z���A���X�ɑ傫��
            if (scaleCnt < Common.MAX_SCALE)
            {
                scaleCnt += samples * Time.deltaTime;
            }
            else
            {
                // �X�P�[���̍ő�l�܂ő傫���Ȃ�΃J�E���g�̃��Z�b�g
                scaleCnt = Common.MAX_SCALE;
            }
        }

        // �V�����X�P�[���l���Z�b�g
        newScale.x = scaleCnt;
        newScale.y = scaleCnt;
        // �q�I�u�W�F�N�g�̃X�P�[����ύX
        this.gameObject.transform.GetChild(0).localScale = newScale;
    }

    /// <summary>
    /// �{�^���̃T�C�Y�����������鏈��
    /// �{�^���ɃJ�[�\�����d�Ȃ��Ă���Ƃ��ɌĂяo��(PointerEnter)
    /// </summary>
    public void ReduceSize()
    {
        // �{�^���ɃJ�[�\�����d�Ȃ��Ă��邽�߃t���O���I��
        isPointerEnter = true;
    }

    /// <summary>
    /// �{�^���̃T�C�Y��傫�����鏈��
    /// �{�^������J�[�\�����O�ꂽ���ɌĂяo��(PointerExit)
    /// </summary>
    public void IncreaseSize()
    {
        // �{�^������J�[�\�����O�ꂽ���߃t���O���I�t
        isPointerEnter = false;
    }

    /// <summary>
    /// �ϐ��̏��������s���֐�
    /// </summary>
    private void Init()
    {
        // �J�E���g�̏�����
        scaleCnt = Common.MAX_SCALE;
        isPointerEnter = false;
        newScale = new Vector3(0, 0, 0);

        // �e�̃T�C�Y�̏�����
        transform.localScale = new Vector3(maxScale, maxScale, maxScale);

    }

    private void Awake()
    {
        // ����������
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        // �t���O�̒l�ɂ��X�P�[����ω�
        if (isPointerEnter)
        {
            // �X�P�[����������
            SetScale(minScale);
        }
        else
        {
            // �X�P�[����傫��
            SetScale(maxScale);
        }
    }
}
