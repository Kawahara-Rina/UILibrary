using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAnimation : MonoBehaviour
{
    // �t�F�[�h�C�����A�E�g�����w�肷�邽�߂̗񋓑�
    public
        enum FadeType
    {
        fadeIn,
        fadeOut
    };

    #region - �t�F�[�h�C���E�A�E�g�̎w��
    [Header("�t�F�[�h�C���E�A�E�g�̎w��")]
    [Tooltip("���I�ɐ��䂵�����ꍇ�́A�C�ӂ̃^�C�~���O�ł��̃t���O��؂�ւ��Ă��������B")]
    #endregion
    [SerializeField] public FadeType fadeType = FadeType.fadeIn;
    
    #region - �ŏ�����A�j���[�V���������邩�ǂ���
    [Header("�ŏ�����A�j���[�V���������邩�ǂ���(true:����,false:���Ȃ�)")]
    [Tooltip("�ŏ�����\�����Ȃ��ꍇ�́A�C�ӂ̃^�C�~���O�ł��̃t���O��true�ɂ��Ă��������B")]
    #endregion
    [SerializeField] public bool isShow = true;

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

    #region - �A�j���[�V�����̑��x
    [Header("�A�j���[�V�����̑��x")]
    [Tooltip("0.1�`4.0�̒l�B0���x��")]
    [Range(Common.MIN_SAMPLES, Common.MAX_SAMPLES)]
    #endregion
    [SerializeField] private float samples=1.0f;

    // ���������x�w�����x�����s�����߂̃t���O
    private bool isFirst;

    /// <summary>
    /// �t�F�[�h�C�����s���^�C�~���O�ŌĂяo���֐�
    /// </summary>
    public void ShowFadeIn()
    {
        fadeType = FadeType.fadeIn;
        isShow = true;
    }

    /// <summary>
    /// �t�F�[�h�A�E�g���s���^�C�~���O�ŌĂяo���֐�
    /// </summary>
    public void ShowFadeOut()
    {
        fadeType = FadeType.fadeOut;
        isShow = true;
    }

    /// <summary>
    /// ����������
    /// </summary>
    private void Init()
    {
        isFirst = true;
    }

    /// <summary>
    /// �g�p�p�r�ɉ����ď����̓����x���w�肷��֐�
    /// </summary>
    private void SetAlpha()
    {
        if (isFirst)
        {
            if (fadeType==FadeType.fadeIn)
            {
                // �t�F�[�h�C���������瓧���ɕω����邽�߁A�A���t�@�l��1.0
                GetComponent<CanvasGroup>().alpha = 1.0f;
            }
            else
            {
                // �t�F�[�h�A�E�g���������獕�ɕω����邽�߁A�A���t�@�l��0
                GetComponent<CanvasGroup>().alpha = 0.0f;
            }

            isFirst = false;
        }
    }

    /// <summary>
    /// �t�F�[�h�C���E�A�E�g�̏���
    /// </summary>
    private void Fade()
    {
        // �t�F�[�h�C��
        if (fadeType == FadeType.fadeIn)
        {
            if (GetComponent<CanvasGroup>().alpha > minAlpha)
            {
                GetComponent<CanvasGroup>().alpha -= Time.deltaTime * samples;
            }

        }
        // �t�F�[�h�A�E�g
        else
        {
            if (GetComponent<CanvasGroup>().alpha < maxAlpha)
            {
                GetComponent<CanvasGroup>().alpha += Time.deltaTime * samples;
            }

        }
    }

    private void Awake()
    {
        // ����������
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        // ���o�J�n�Ńt�F�[�h�C���E�A�E�g
        if (isShow)
        {
            // �����̓����x��ݒ�
            SetAlpha();

            // �t�F�[�h����
            Fade();
        }

    }
}
