using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SlideAnimation : MonoBehaviour
{
    // �萔
    private const float ADD_SPEED = 5000.0f;

    // �X���C�h�̕������w�肷�邽�߂̗񋓑�
    public enum FlowType
    {
        UpToBottom,
        BottomToUp,
        RightToLeft,
        LeftToRight
    };

    // �X���C�h�C�����A�E�g���w�肷�邽�߂̗񋓑�
    public enum SlideType
    {
        SlideIn,
        SlideOut
    };

    #region - �X���C�h�����̎w��p
    [Header("�X���C�h�����̎w��")]
    #endregion
    [SerializeField] private FlowType flowType = FlowType.UpToBottom;

    #region - �X���C�h�A�E�g���̕����w��
    [Header("�X���C�h�A�E�g�����̎w��\ntrue �F�t�����ɃX���C�h�A�E�g(�X���C�h�C���̊J�n�ʒu�ɖ߂铮��)\nfalse�F����ʍs�ɃX���C�h�A�E�g")]
    #endregion
    [SerializeField] private bool isReverse = false;

    #region - �X���C�h"�C��"���̊J�n�ʒu(���[�J���|�W�V����)
    [Header("�X���C�h�h�C���h���̊J�n�ʒu")]
    #endregion
    [SerializeField] private Vector2 inStartPos;

    #region - �X���C�h"�C��"���̒�~�ʒu(���[�J���|�W�V����)
    [Header("�X���C�h�h�C���h���̒�~�ʒu")]
    #endregion
    [SerializeField] private Vector2 inStopPos;

    #region - �A�j���[�V�����̑��x
    [Header("�A�j���[�V�����̑��x")]
    [Tooltip("0.1�`4.0�̒l�B0���x��")]
    [Range(Common.MIN_SAMPLES, Common.MAX_SAMPLES)]
    #endregion
    [SerializeField] private float samples = 2.0f;

    // ���݂̈ʒu�擾�p
    private Vector2 pos;

    // �X���C�h�C���E�A�E�g�ǂ��炩�̎w��p
    private SlideType slideType;

    // �A�j���[�V�������Đ����邩�ǂ���
    private bool isShow = false;

    // ���߂̃X���C�h�C���̕�����ς��Ȃ����߂̃t���O
    private bool isFirst = true;

    private FlowType reverseFlowType;
    private FlowType beforeFlowType;


    /// <summary>
    /// �X���C�h�C���������Ƃ��ɌĂяo���֐�
    /// </summary>
    public void SlideIn()
    {
        slideType = SlideType.SlideIn;
        transform.localPosition = new Vector2(inStartPos.x, inStartPos.y);

        // �X���C�h�C�����̗�����Đݒ�
        if (isReverse)
        {
            flowType = beforeFlowType;
        }

        isShow = true;
    }

    /// <summary>
    /// �X���C�h�A�E�g�������Ƃ��ɌĂяo���֐�
    /// </summary>
    public void SlideOut()
    {
        slideType = SlideType.SlideOut;
        transform.localPosition = new Vector2(inStopPos.x, inStopPos.y);

        // �X���C�h�A�E�g���t�����̏ꍇ
        if (isReverse)
        {
            // ������Đݒ�
            flowType = reverseFlowType;
        }

        isShow = true;
    }

    /// <summary>
    /// ����������
    /// </summary>
    private void Init()
    {
        // �����ʒu�ݒ�
        transform.localPosition = new Vector2(inStartPos.x,inStartPos.y);

        // �t�����ɃX���C�h�A�E�g����ꍇ
        if (isReverse) {
            switch (flowType)
            {
                case FlowType.BottomToUp:
                    reverseFlowType = FlowType.UpToBottom;
                    break;

                case FlowType.UpToBottom:
                    reverseFlowType = FlowType.BottomToUp;
                    break;

                case FlowType.RightToLeft:
                    reverseFlowType = FlowType.LeftToRight;
                    break;

                case FlowType.LeftToRight:
                    reverseFlowType = FlowType.RightToLeft;
                    break;
            }

            // �X���C�h�C�����̕�����ۑ����Ă���
            beforeFlowType = flowType;
        }
    }

    /// <summary>
    /// �ړ�����(�X���C�h)����
    /// </summary>
    private void Slide()
    {
        // ���݂̍��W���擾
        pos = transform.localPosition;

        // �X���C�h�̕����ɉ����Ĉړ�������ύX
        switch (flowType)
        {
            case FlowType.UpToBottom:
                #region �ォ�牺
                // �X���C�h�C�����̈ړ�����
                if (slideType == SlideType.SlideIn)
                {
                    if (pos.y > inStopPos.y)
                    {
                        pos.y -= Time.deltaTime * samples * ADD_SPEED;
                    }
                    else
                    {
                        // �ʒu�̕␳����
                        pos.y = inStopPos.y;
                    }
                }
                // �X���C�h�A�E�g���̈ړ�����
                else
                {
                    if (isReverse)
                    {
                        if (pos.y > inStartPos.y)
                        {
                            pos.y -= Time.deltaTime * samples * ADD_SPEED;
                        }
                        else
                        {
                            pos.y = inStartPos.y;
                        }
                    }
                    else
                    {
                        if (pos.y > -inStartPos.y)
                        {
                            pos.y -= Time.deltaTime * samples * ADD_SPEED;
                        }
                        else
                        {
                            pos.y = -inStartPos.y;
                        }
                    }
                    
                }
                break;
            #endregion

            case FlowType.BottomToUp:
                #region �������
                // �X���C�h�C�����̈ړ�����
                if (slideType == SlideType.SlideIn)
                {
                    if (pos.y < inStopPos.y)
                    {
                        pos.y += Time.deltaTime * samples * ADD_SPEED;
                    }
                    else
                    {
                        // �ʒu�̕␳����
                        pos.y = inStopPos.y;
                    }
                }
                // �X���C�h�A�E�g���̈ړ�����
                else
                {
                    if (isReverse)
                    {
                        if (pos.y < inStartPos.y)
                        {
                            pos.y += Time.deltaTime * samples * ADD_SPEED;
                        }
                        else
                        {
                            pos.y = inStartPos.y;
                        }
                    }
                    else
                    {
                        if (pos.y < -inStartPos.y)
                        {
                            pos.y += Time.deltaTime * samples * ADD_SPEED;
                        }
                        else
                        {
                            pos.y = -inStartPos.y;
                        }
                    }
                }
                break;
            #endregion

            case FlowType.RightToLeft:
                #region �E���獶
                // �X���C�h�C�����̈ړ�����
                if (slideType == SlideType.SlideIn)
                {
                    if (pos.x > inStopPos.x)
                    {
                        pos.x -= Time.deltaTime * samples * ADD_SPEED;
                    }
                    else
                    {
                        // �ʒu�̕␳����
                        pos.x = inStopPos.x;
                    }
                }
                // �X���C�h�A�E�g���̈ړ�����
                else
                {
                    if (isReverse)
                    {
                        if (pos.x > inStartPos.x)
                        {
                            pos.x -= Time.deltaTime * samples * ADD_SPEED;
                        }
                        else
                        {
                            pos.x = inStartPos.x;
                        }
                    }
                    else
                    {
                        if (pos.x > -inStartPos.x)
                        {
                            pos.x -= Time.deltaTime * samples * ADD_SPEED;
                        }
                        else
                        {
                            pos.x = -inStartPos.x;
                        }
                    }
                }
                break;
            #endregion

            case FlowType.LeftToRight:
                #region ������E
                // �X���C�h�C�����̈ړ�����
                if (slideType == SlideType.SlideIn)
                {
                    if (pos.x < inStopPos.x)
                    {
                        pos.x += Time.deltaTime * samples * ADD_SPEED;
                    }
                    else
                    {
                        // �ʒu�̕␳����
                        pos.x = inStopPos.x;
                    }
                }
                // �X���C�h�A�E�g���̈ړ�����
                else
                {
                    if (isReverse)
                    {
                        if (pos.x < inStartPos.x)
                        {
                            pos.x += Time.deltaTime * samples * ADD_SPEED;
                        }
                        else
                        {
                            pos.x = inStartPos.x;
                        }
                    }
                    else
                    {
                        if (pos.x < -inStartPos.x)
                        {
                            pos.x += Time.deltaTime * samples * ADD_SPEED;
                        }
                        else
                        {
                            pos.x = -inStartPos.x;
                        }
                    }
                }
                break;
                #endregion
        }

        // ���݂̍��W��ύX
        transform.localPosition = new Vector2(pos.x, pos.y);
    }

    private void Awake()
    {
        // ����������
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        // �A�j���[�V�����Đ���
        if (isShow)
        {
            // �ړ��������s
            Slide();
        }
    }
}
