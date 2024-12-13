using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideManager : MonoBehaviour
{
    // �萔
    private const float ADD_SPEED = 5000.0f;

    // �X���C�h�̕������w�肷�邽�߂̗񋓑�
    private enum FlowType
    {
        UpToBottom,
        BottomToUp,
        RightToLeft,
        LeftToRight
    };

    // �X���C�h�C�����A�E�g���w�肷�邽�߂̗񋓑�
    private enum SlideType
    {
        SlideIn,
        SlideOut
    };

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

                if (slideType == SlideType.SlideIn)
                {
                    if (pos.y > inStopPos)
                    {
                        pos.y -= Time.deltaTime * samples * ADD_SPEED;
                    }
                    else
                    {
                        pos.y = inStopPos;
                    }
                }
                else
                {
                    if (pos.y > outStopPos)
                    {
                        pos.y -= Time.deltaTime * samples * ADD_SPEED;
                    }
                    else
                    {
                        pos.y = outStopPos;
                    }
                }
                break;

            case FlowType.BottomToUp:

                if (slideType == SlideType.SlideIn)
                {
                    if (pos.y < inStopPos)
                    {
                        pos.y += Time.deltaTime * samples * ADD_SPEED;
                    }
                    else
                    {
                        pos.y = inStopPos;
                    }
                }
                else
                {
                    if (pos.y < outStopPos)
                    {
                        pos.y += Time.deltaTime * samples * ADD_SPEED;
                    }
                    else
                    {
                        pos.y = outStopPos;
                    }
                }
                break;

            case FlowType.RightToLeft:

                if (slideType == SlideType.SlideIn)
                {
                    if (pos.x > inStopPos)
                    {
                        pos.x -= Time.deltaTime * samples * ADD_SPEED;
                    }
                    else
                    {
                        pos.x = inStopPos;
                    }
                }
                else
                {
                    if (pos.x > outStopPos)
                    {
                        pos.x -= Time.deltaTime * samples * ADD_SPEED;
                    }
                    else
                    {
                        pos.x = outStopPos;
                    }
                }
                break;

            case FlowType.LeftToRight:

                if (slideType == SlideType.SlideIn)
                {
                    if (pos.x < inStopPos)
                    {
                        pos.x += Time.deltaTime * samples * ADD_SPEED;
                    }
                    else
                    {
                        pos.x = inStopPos;
                    }
                }
                else
                {
                    if (pos.x < outStopPos)
                    {
                        pos.x += Time.deltaTime * samples * ADD_SPEED;
                    }
                    else
                    {
                        pos.x = outStopPos;
                    }
                }
                break;
        }

        // ���݂̍��W��ύX
        transform.localPosition = new Vector2(pos.x, pos.y);
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
