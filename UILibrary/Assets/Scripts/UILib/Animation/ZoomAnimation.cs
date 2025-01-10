using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomAnimation : MonoBehaviour
{
    // �萔
    private const float ADD_SPEED = 10.0f;

    // �t�F�[�h�C�����A�E�g�����w�肷�邽�߂̗񋓑�
    public
        enum ZoomType
    {
        ZoomIn,
        ZoomOut
    };

    #region - �Y�[���C���E�A�E�g�̎w��
    [Header("�Y�[���C���E�A�E�g�̎w��")]
    [Tooltip("���I�ɐ��䂵�����ꍇ�́A�C�ӂ̃^�C�~���O�ł��̃t���O��؂�ւ��Ă��������B")]
    #endregion
    [SerializeField] public ZoomType zoomType = ZoomType.ZoomIn;

    #region - �ŏ�����A�j���[�V���������邩�ǂ���
    [Header("�ŏ�����A�j���[�V���������邩�ǂ���(true:����,false:���Ȃ�)")]
    [Tooltip("�ŏ�����\�����Ȃ��ꍇ�́A�C�ӂ̃^�C�~���O�ł��̃t���O��true�ɂ��Ă��������B")]
    #endregion
    [SerializeField] public bool isShow = true;

    #region - �X�P�[���̍ő�l
    [Header("�X�P�[���̍ő�l(�g�厞)")]
    [Tooltip("0.0�`1.0�̒l�B0��������")]
    [Range(Common.MIN_SCALE, Common.MAX_SCALE)]
    #endregion
    [SerializeField] private float maxScale = 1.0f;

    #region - �X�P�[���̍ŏ��l
    [Header("�X�P�[���̍ŏ��l(�k����)")]
    [Tooltip("0.0�`1.0�̒l�B0��������")]
    [Range(Common.MIN_SCALE, Common.MAX_SCALE)]
    #endregion
    [SerializeField] private float minScale = 0;

    #region - �A�j���[�V�����̑��x
    [Header("�A�j���[�V�����̑��x")]
    [Tooltip("0.1�`4.0�̒l�B0���x��")]
    [Range(Common.MIN_SAMPLES, Common.MAX_SAMPLES)]
    #endregion
    [SerializeField] private float samples = 1.0f;

    // �����X�P�[���̐ݒ����x�����s�����߂̃t���O
    private bool isFirst;

    // �X�P�[���擾�p
    private float scale;

    /// <summary>
    /// �Y�[���C�����s���^�C�~���O�ŌĂяo���֐�
    /// </summary>
    public void ShowZoomIn()
    {
        zoomType = ZoomType.ZoomIn;
        isShow = true;
    }

    /// <summary>
    /// �Y�[���A�E�g���s���^�C�~���O�ŌĂяo���֐�
    /// </summary>
    public void ShowZoomOut()
    {
        zoomType = ZoomType.ZoomOut;
        isShow = true;
    }

    /// <summary>
    /// ����������
    /// </summary>
    private void Init()
    {
        isFirst = true;
    }

    private void Awake()
    {
        // ����������
        Init();
    }

    /// <summary>
    /// �g�p�p�r�ɉ����ď����̃X�P�[����ݒ肷��֐�
    /// </summary>
    private void SetScale()
    {
        if (isFirst)
        {
            if (zoomType == ZoomType.ZoomIn)
            {
                // �Y�[���C�����������ɕω����邽�߁A�X�P�[����minScale
                scale = minScale;
            }
            else
            {
                // �Y�[���A�E�g���傩�珬�ɕω����邽�߁A�X�P�[����maxScale
                scale = maxScale;
            }

            isFirst = false;
        }
    }

    /// <summary>
    /// �Y�[���C���E�A�E�g�̏���
    /// </summary>
    private void Zoom()
    {
        // �Y�[���C��
        if (zoomType == ZoomType.ZoomIn)
        {
            if (scale < maxScale)
            {
                scale+= Time.deltaTime * samples * ADD_SPEED;
            }
            else
            {
                scale = maxScale;
            }

        }
        // �Y�[���A�E�g
        else
        {
            if (scale > minScale)
            {
                scale -= Time.deltaTime * samples * ADD_SPEED;
            }
            else
            {
                scale = minScale;
            }

        }

        transform.localScale = new Vector3(scale,scale,scale);
    }

    // Update is called once per frame
    void Update()
    {
        // ���o�J�n�ŃY�[���C���E�A�E�g
        if (isShow)
        {
            // �����̃X�P�[����ݒ�
            SetScale();

            // �Y�[������
            Zoom();
        }
    }
}
