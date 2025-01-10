using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    #region - �X�R�A��\������Text
    [Header("�X�R�A��\������Text")]
    #endregion
    [SerializeField] private Text text;

    #region - �X�R�A�̏����l
    [Header("�X�R�A�̏����l")]
    #endregion
    [SerializeField] private float score = 0.0f;

    #region - �X�R�A�̏���l
    [Header("�X�R�A�̏���l")]
    #endregion
    [SerializeField] private float maxScore = 100.0f;

    #region - �X�R�A�̉����l
    [Header("�X�R�A�̉����l")]
    #endregion
    [SerializeField] private float minScore = 0.0f;

    #region - 1�񂲂Ƃ̃X�R�A�ւ̉��Z��
    [Header("1�񂲂Ƃ̃X�R�A�ւ̉��Z��")]
    #endregion
    [SerializeField] private float addScore = 10.0f;

    #region - 1�񂲂Ƃ̃X�R�A�ւ̌��Z��
    [Header("1�񂲂Ƃ̃X�R�A�ւ̌��Z��")]
    #endregion
    [SerializeField] private float subScore = 10.0f;

    #region - �����_�ʒu�̎w��
    [Header("�����_�ʒu�̎w��\nNone : �����_�ȉ��\���Ȃ�\nFirst : ������1�ʂ܂ŕ\��\nSecond : ������2�ʂ܂ŕ\��")]
    #endregion
    [SerializeField] private Common.DecimalPlace decimalPlace = Common.DecimalPlace.None;

    // �����_�ʒu�w��p
    private string format;

    /// <summary>
    /// ����������
    /// </summary>
    private void Init()
    {
        // �����_�ʒu�w��
        format = Common.SetDecimalPlace(decimalPlace);
    }

    /// <summary>
    /// �X�R�A�����Z���鏈��
    /// �C�ӂ̃^�C�~���O�ł��̊֐����Ăяo���Ďg�p���Ă��������B
    /// </summary>
    public void CountUpScore()
    {
        if (score < maxScore)
        {
            score += addScore;
        }
        else
        {
            score = maxScore;
        }
    }

    /// <summary>
    /// �X�R�A�����Z���鏈��
    /// �C�ӂ̃^�C�~���O�ł��̊֐����Ăяo���Ďg�p���Ă��������B
    /// </summary>
    public void CountDownScore()
    {
        if (score > minScore)
        {
            score -=Mathf.Abs(subScore);
        }
        else
        {
            score = minScore;
        }
    }

    /// <summary>
    /// �X�R�A��Ԃ�����
    /// score�̒l�ɉ������������������ꍇ�́A���̊֐��𗘗p���Ă��������B
    /// </summary>
    /// <returns></returns>
    public float GetScore()
    {
        return score;
    }

    private void Awake()
    {
        // ����������
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        // �e�L�X�g�\��
        text.text = score.ToString(format);
    }
}
