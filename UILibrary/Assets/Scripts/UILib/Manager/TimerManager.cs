/*
    TimerManager.cs

    �^�C�}�[�̊Ǘ��N���X
*/
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    
    #region - �^�C�}�[��\������Text
    [Header("�^�C�}�[��\������Text")]
    #endregion
    [SerializeField] private Text text;

    #region - �^�C�}�[�̏����l
    [Header("�^�C�}�[�̏����l")]
    #endregion
    [SerializeField] private float timer = 0.0f;

    #region - �^�C�}�[�̒�~�l
    [Header("�^�C�}�[�̒�~�l")]
    #endregion
    [SerializeField] private float stopTime = 10.0f;

    #region - 1�b���Ƃ̃^�C�}�[�ւ̉��Z��
    [Header("1�b���Ƃ̃^�C�}�[�ւ̉��Z��\n�� ) 1.0��1�b��1����Z�A20.0��1�b��20����Z")]
    #endregion
    [SerializeField] private float addTime = 1.0f;

    #region - �J�E���g�̎�ނ̎w��
    [Header("�J�E���g�̎�ނ̎w��\ntrue : �J�E���g�A�b�v\nfalse : �J�E���g�_�E��")]
    #endregion
    [SerializeField] private bool isCountUp = true;

    #region - �^�C�}�[���~���邩�ǂ���
    [Header("�^�C�}�[���~���邩�ǂ���\ntrue : ��~\nfalse : �ĊJ")]
    #endregion
    [SerializeField] private bool isStop = true;

    #region - �����_�ʒu�̎w��
    [Header("�����_�ʒu�̎w��\nNone : �����_�ȉ��\���Ȃ�\nFirst : ������1�ʂ܂ŕ\��\nSecond : ������2�ʂ܂ŕ\��")]
    #endregion
    [SerializeField] private uiCommon.DecimalPlace decimalPlace = uiCommon.DecimalPlace.None;

    // �����_�ʒu�w��p
    private string format;

    /// <summary>
    /// ����������
    /// </summary>
    private void Init()
    {
        // �����_�ʒu�w��
        format = uiCommon.SetDecimalPlace(decimalPlace);

        // �����l��\��
        text.text = timer.ToString(format);
    }

    /// <summary>
    /// �^�C�}�[���J�E���g�A�b�v���鏈��
    /// </summary>
    private void CountUpTimer()
    {
        if (timer < stopTime)
        {
            timer += Mathf.Abs(addTime) * Time.deltaTime;
        }
        else
        {
            timer = stopTime;
        }
    }

    /// <summary>
    /// �^�C�}�[���J�E���g�_�E�����鏈��
    /// </summary>
    private void CountDownTimer()
    {
        if (timer > stopTime)
        {
            timer -= Mathf.Abs(addTime) * Time.deltaTime;
        }
        else
        {
            timer = stopTime;
        }
    }

    /// <summary>
    /// �^�C�}�[�̃J�E���g���~����֐�
    /// �^�C�}�[�̒�~�E�ĊJ���������ꍇ�́A���̊֐���C�ӂ̃^�C�~���O�ŌĂяo���Ă��������B
    /// </summary>
    public void CountStop()
    {
        isStop = true;
    }

    /// <summary>
    /// �^�C�}�[�̃J�E���g���ĊJ����֐�
    /// �^�C�}�[�̒�~�E�ĊJ���������ꍇ�́A���̊֐���C�ӂ̃^�C�~���O�ŌĂяo���Ă��������B
    /// </summary>
    public void CountStart()
    {
        isStop = false;
    }

    /// <summary>
    /// timer��n���֐�
    /// timer�̒l�ɉ������������������ꍇ�́A���̊֐��𗘗p���Ă��������B
    /// </summary>
    /// <returns></returns>
    public float GetTimer()
    {
        return timer;
    }

    private void Awake()
    {
        // ����������
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStop)
        {
            // �J�E���g�_�E���E�A�b�v����
            if (isCountUp)
            {
                CountUpTimer();
            }
            else
            {
                CountDownTimer();
            }

            // �e�L�X�g�\��
            text.text = timer.ToString(format);
        }
    }
}
