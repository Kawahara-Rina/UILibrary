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

    #region - �X���C�h�����̎w��
    [Header("�X���C�h�����̎w��")]
    [Tooltip("���I�ɐ��䂵�����ꍇ�́A�C�ӂ̃^�C�~���O�ł��̃t���O��؂�ւ��Ă��������B")]
    #endregion
    [SerializeField] public FlowType flowType = FlowType.UpToBottom;

    #region - �ŏ�����A�j���[�V���������邩�ǂ���
    [Header("�ŏ�����A�j���[�V���������邩�ǂ���(true:����,false:���Ȃ�)")]
    [Tooltip("�ŏ�����\�����Ȃ��ꍇ�́A�C�ӂ̃^�C�~���O�ł��̃t���O��true�ɂ��Ă��������B")]
    #endregion
    [SerializeField] public bool isShow = true;

    #region - �X���C�h"�C��"���̊J�n�ʒu(���[�J���|�W�V����)
    [Header("�X���C�h�h�C���h���̊J�n�ʒu")]
    #endregion
    [SerializeField] private float startPos = 0;

    #region - �X���C�h"�C��"���̒�~�ʒu(���[�J���|�W�V����)
    [Header("�X���C�h�h�C���h���̒�~�ʒu")]
    #endregion
    [SerializeField] private float stopPos = 1700f;

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

    // ���݂̈ʒu�擾�p
    private Vector2 pos;

    /// <summary>
    /// �と�������̃X���C�h�����s����֐�
    /// </summary>
    public void ShowUpToBottom()
    {
        transform.localPosition = new Vector2(pos.x, startPos);
        flowType = FlowType.UpToBottom;
        isShow = true;
    }

    /// <summary>
    /// ����������̃X���C�h�����s����֐�
    /// </summary>
    public void ShowBottomToUp()
    {
        transform.localPosition = new Vector2(pos.x, startPos);
        flowType = FlowType.BottomToUp;
        isShow = true;
    }

    /// <summary>
    /// �E���������̃X���C�h�����s����֐�
    /// </summary>
    public void ShowRightToLeft()
    {
        transform.localPosition = new Vector2(startPos,pos.y);
        flowType = FlowType.RightToLeft;
        isShow = true;
    }

    /// <summary>
    /// �����E�����̃X���C�h�����s����֐�
    /// </summary>
    public void ShowLeftToRight()
    {
        transform.localPosition = new Vector2(startPos, pos.y);
        flowType = FlowType.LeftToRight;
        isShow = true;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO ��~�ʒu�Ŏ~�܂�Ȃ��̂��C��
        // TODO ���ȏ�X���C�h�������Ƃ��̓���̏C��
        if (isShow)
        {
            // ���݂̍��W���擾
            pos = transform.localPosition;

            // �X���C�h�̕����ɉ����Ĉړ�������ύX
            switch (flowType)
            {
                case FlowType.UpToBottom:

                    if (pos.y > stopPos)
                    {
                        pos.y -= Time.deltaTime * samples * 3000.0f;
                    }
                    break;

                case FlowType.BottomToUp:
                    if (pos.y < stopPos)
                    {
                        pos.y += Time.deltaTime * samples*3000.0f ;
                    }
                    break;

                case FlowType.RightToLeft:

                    if (pos.x > stopPos)
                    {
                        pos.x -= Time.deltaTime * samples * 3000.0f;
                    }
                    break;

                case FlowType.LeftToRight:

                    if (pos.x < stopPos)
                    {
                        pos.x += Time.deltaTime * samples * 3000.0f;
                    }
                    break;
            }

            // ���݂̍��W��ύX
            transform.localPosition = new Vector2(pos.x, pos.y);
        }
    }
}
