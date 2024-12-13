using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideManager : MonoBehaviour
{
    // �t�F�[�h�C�����A�E�g�����w�肷�邽�߂̗񋓑�
    public
        enum FlowType
    {
        UpToBottom,
        BottomToUp,
        RightToLeft,
        LeftToRight
    };

    public
        enum SlideType
    {
        SlideIn,
        SlideOut
    };

    /*
    #region - �X���C�h�����̎w��
    [Header("�X���C�h�����̎w��")]
    [Tooltip("���I�ɐ��䂵�����ꍇ�́A�C�ӂ̃^�C�~���O�ł��̃t���O��؂�ւ��Ă��������B")]
    #endregion
    [SerializeField] public FlowType flowType = FlowType.UpToBottom;
    */

    #region - �X���C�h"�C��"���̊J�n�ʒu(���[�J���|�W�V����)
    [Header("�X���C�h�h�C���h���̊J�n�ʒu")]
    #endregion
    [SerializeField] private float inStartPos = 0;

    #region - �X���C�h"�C��"���̒�~�ʒu(���[�J���|�W�V����)
    [Header("�X���C�h�h�C���h���̒�~�ʒu")]
    #endregion
    [SerializeField] private float inStopPos = 0;

    #region - �X���C�h"�A�E�g"���̊J�n�ʒu(���[�J���|�W�V����)
    [Header("�X���C�h�h�A�E�g�h���̊J�n�ʒu")]
    #endregion
    [SerializeField] private float outStartPos = 0;

    #region - �X���C�h"�A�E�g"���̒�~�ʒu(���[�J���|�W�V����)
    [Header("�X���C�h�h�A�E�g�h���̒�~�ʒu")]
    #endregion
    [SerializeField] private float outStopPos = 0;

    #region - �A�j���[�V�����̑��x
    [Header("�A�j���[�V�����̑��x")]
    [Tooltip("0.1�`4.0�̒l�B0���x��")]
    [Range(Common.MIN_SAMPLES, Common.MAX_SAMPLES)]
    #endregion
    [SerializeField] private float samples = 1.0f;

    /*
    #region - �����x�̕ω������邩�ǂ����̃t���O
    [Header("�����x�̕ω������邩���w��(true:�ω�����,false:�ω��Ȃ�)")]
    #endregion
    [SerializeField] public bool isChangeAlpha = false;

    #region - �����x�̍ő�l
    [Header("�����x�̍ő�l(CanvasGroup�̓����x)")]
    [Tooltip("0.0�`1.0�̒l�B0��������")]
    [Range(Common.MIN_ALPHA, Common.MAX_ALPHA)]
    #endregion
    [SerializeField] private float maxAlpha = 1.0f;

    #region - �����x�̍ŏ��l
    [Header("�����x�̍ŏ��l(CanvasGroup�̓����x)")]
    [Tooltip("0.0�`1.0�̒l�B0��������")]
    [Range(Common.MIN_ALPHA, Common.MAX_ALPHA)]
    #endregion
    [SerializeField] private float minAlpha = 0;
    */

    // �X���C�h�����̎w��p
    private FlowType flowType = FlowType.UpToBottom;

    // ���݂̈ʒu�擾�p
    private Vector2 pos;

    // �X���C�h�C���E�A�E�g�ǂ��炩�̃t���O
    private SlideType slideType;
    // �A�j���[�V�������Đ����邩�ǂ���
    private bool isShow = false;

    /// <summary>
    /// �X���C�h�C���������Ƃ��ɌĂяo���֐�
    /// </summary>
    public void SlideIn()
    {
        slideType = SlideType.SlideIn;
        isShow = true;
    }

    /// <summary>
    /// �X���C�h�A�E�g�������Ƃ��ɌĂяo���֐�
    /// </summary>
    public void SlideOut()
    {
        slideType = SlideType.SlideOut;
        isShow = true;
    }

    /// <summary>
    /// �と�������̃X���C�h�����s����֐�
    /// </summary>
    public void ShowUpToBottom()
    {
        if (slideType == SlideType.SlideIn)
        {
            transform.localPosition = new Vector2(inStopPos, inStartPos);
        }
        else
        {
            transform.localPosition = new Vector2(pos.x, outStartPos);
        }

        flowType = FlowType.UpToBottom;
    }

    /// <summary>
    /// ����������̃X���C�h�����s����֐�
    /// </summary>
    public void ShowBottomToUp()
    {
        if (slideType == SlideType.SlideIn)
        {
            transform.localPosition = new Vector2(pos.x, inStartPos);
        }
        else
        {
            transform.localPosition = new Vector2(pos.x, outStartPos);
        }

        flowType = FlowType.BottomToUp;
    }

    /// <summary>
    /// �E���������̃X���C�h�����s����֐�
    /// </summary>
    public void ShowRightToLeft()
    {
        if (slideType == SlideType.SlideIn)
        {
            transform.localPosition = new Vector2(inStartPos, outStartPos);
        }
        else
        {
            transform.localPosition = new Vector2(outStartPos, pos.y);
        }
        flowType = FlowType.RightToLeft;
    }

    /// <summary>
    /// �����E�����̃X���C�h�����s����֐�
    /// </summary>
    public void ShowLeftToRight()
    {
        if (slideType == SlideType.SlideIn)
        {
            transform.localPosition = new Vector2(inStartPos, outStartPos);
        }
        else
        {
            transform.localPosition = new Vector2(outStartPos, pos.y);
        }
        flowType = FlowType.LeftToRight;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO ��~�ʒu�Ŏ~�܂�Ȃ��̂��C��
        if (isShow)
        {
            // ���݂̍��W���擾
            pos = transform.localPosition;

            // �X���C�h�̕����ɉ����Ĉړ�������ύX
            switch (flowType)
            {
                case FlowType.UpToBottom:

                    if (slideType == SlideType.SlideIn)
                    {
                        if (pos.y > inStopPos)
                        {
                            pos.y -= Time.deltaTime * samples * 3000.0f;
                        }
                    }
                    else
                    {
                        if (pos.y > outStopPos)
                        {
                            pos.y -= Time.deltaTime * samples * 3000.0f;
                        }
                    }
                    break;

                case FlowType.BottomToUp:

                    if (slideType == SlideType.SlideIn)
                    {
                        if (pos.y < inStopPos)
                        {
                            pos.y += Time.deltaTime * samples * 3000.0f;
                        }
                    }
                    else
                    {
                        if (pos.y < outStopPos)
                        {
                            pos.y += Time.deltaTime * samples * 3000.0f;
                        }
                    }
                    break;

                case FlowType.RightToLeft:

                    if (slideType == SlideType.SlideIn)
                    {
                        if (pos.x > inStopPos)
                        {
                            pos.x -= Time.deltaTime * samples * 3000.0f;
                        }
                    }
                    else
                    {
                        if (pos.x > outStopPos)
                        {
                            pos.x -= Time.deltaTime * samples * 3000.0f;
                        }
                    }
                    break;

                case FlowType.LeftToRight:

                    if (slideType == SlideType.SlideIn)
                    {
                        if (pos.x < inStopPos)
                        {
                            pos.x += Time.deltaTime * samples * 3000.0f;
                        }
                    }
                    else
                    {
                        if (pos.x < outStopPos)
                        {
                            pos.x += Time.deltaTime * samples * 3000.0f;
                        }
                    }
                    break;
            }

            // ���݂̍��W��ύX
            transform.localPosition = new Vector2(pos.x, pos.y);
        }
    }
}
