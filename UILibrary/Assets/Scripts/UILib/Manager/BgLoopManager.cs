/*
    BgLoopManager.cs

    �w�i�̃��[�v�\���Ǘ��N���X
*/
using UnityEngine;

public class BgLoop : MonoBehaviour
{
    // �萔
    private const float ADD_SPEED = 500.0f;

    // �X�N���[���̕���
    private enum Direction {
        Up,
        Down,
        Right,
        Left
    }

    #region - �X�N���[���̕���
    [Header("�X�N���[���̕���")]
    #endregion
    [SerializeField] private Direction direction = Direction.Left;

    #region - �g�p����Image�@
    [Header("�g�p����Image�@\n���摜1,2�̓X�N���[�������ɍ��킹�Ĕz�u���Ă�������")]
    [Tooltip("Canvas�ɐݒu���Ă���Image���i�[���Ă�������")]
    #endregion
    [SerializeField] private GameObject image1;

    #region - �g�p����Image�A
    [Header("�g�p����Image�A\n���摜1,2�̓X�N���[�������ɍ��킹�Ĕz�u���Ă�������")]
    [Tooltip("Canvas�ɐݒu���Ă���Image���i�[���Ă�������")]
    #endregion
    [SerializeField] private GameObject image2;

    #region - �A�j���[�V�����̑��x
    [Header("�A�j���[�V�����̑��x")]
    [Tooltip("0.1�`4.0�̒l�B0���x��")]
    [Range(uiCommon.MIN_SAMPLES, uiCommon.MAX_SAMPLES)]
    #endregion
    [SerializeField] private float samples = 1.0f;

    #region - �X�N���[�����~���邩
    [Header("�X�N���[�����~���邩\ntrue : ��~����Afalse : ��~���Ȃ�")]
    [Tooltip("���I�ɐ��䂵�����ꍇ�́AScrollStart(),ScrollStop()���Ăяo���Ă��������B")]
    #endregion
    [SerializeField] private bool isStop = false;

    // �w�i�摜�̉����E�c��
    private float width;
    private float height;

    // ������Ԃ̍��W�擾�p
    private Vector3 startPosition1;
    private Vector3 startPosition2;

    // ���W�X�V�p
    private Vector3 pos1;
    private Vector3 pos2;

    /// <summary>
    /// �X�N���[�����~����֐�
    /// </summary>
    public void ScrollStop()
    {
        isStop = true;
    }

    /// <summary>
    /// �X�N���[�����J�n����֐�
    /// </summary>
    public void ScrollStart()
    {
        isStop = false;
    }

    /// <summary>
    /// ����������
    /// </summary>
    private void Init()
    {
        // �����ʒu�擾
        startPosition1 = image1.transform.localPosition;
        startPosition2 = image2.transform.localPosition;

        // �摜�̕��E�����擾
        var rect = image1.GetComponent<RectTransform>().rect;
        width = rect.width;
        height = rect.height;
    }

    /// <summary>
    /// �w�肵�������Ɍ����ăX�N���[������֐�
    /// </summary>
    private void Scroll()
    {
        // �e�����ɃX�N���[��
        switch (direction)
        {
            case Direction.Up:
                #region ��ɃX�N���[��
                pos1.y = image1.transform.localPosition.y + Time.deltaTime * samples  * ADD_SPEED;
                pos2.y = image2.transform.localPosition.y + Time.deltaTime * samples  * ADD_SPEED;

                image1.transform.localPosition = pos1;
                image2.transform.localPosition = pos2;

                // �w�i����ʊO�ɏo����Ĕz�u
                if (image1.transform.localPosition.y >= height)
                {
                    image1.transform.localPosition = new Vector3(startPosition1.x, image2.transform.localPosition.y - height, startPosition1.z);
                }
                if (image2.transform.localPosition.y >= height)
                {
                    image2.transform.localPosition = new Vector3(startPosition2.x, image1.transform.localPosition.y - height, startPosition2.z);
                }
                break;
            #endregion

            case Direction.Down:
                #region ���ɃX�N���[��
                pos1.y = image1.transform.localPosition.y - Time.deltaTime * samples  * ADD_SPEED;
                pos2.y = image2.transform.localPosition.y - Time.deltaTime * samples  * ADD_SPEED;

                image1.transform.localPosition = pos1;
                image2.transform.localPosition = pos2;

                // �w�i����ʊO�ɏo����Ĕz�u
                if (image1.transform.localPosition.y <= -height)
                {
                    image1.transform.localPosition = new Vector3(startPosition1.x, image2.transform.localPosition.x + height, startPosition1.z);
                }
                if (image2.transform.localPosition.y <= -height)
                {
                    image2.transform.localPosition = new Vector3(startPosition2.x, image1.transform.localPosition.x + height, startPosition2.z);
                }
                break;
            #endregion

            case Direction.Right:
                #region �E�ɃX�N���[��
                pos1.x = image1.transform.localPosition.x + Time.deltaTime * samples  * ADD_SPEED;
                pos2.x = image2.transform.localPosition.x + Time.deltaTime * samples  * ADD_SPEED;

                image1.transform.localPosition = pos1;
                image2.transform.localPosition = pos2;

                // �w�i����ʊO�ɏo����Ĕz�u
                if (image1.transform.localPosition.x >= width)
                {
                    image1.transform.localPosition = new Vector3(image2.transform.localPosition.x - width, startPosition1.y, startPosition1.z);
                }
                if (image2.transform.localPosition.x >= width)
                {
                    image2.transform.localPosition = new Vector3(image1.transform.localPosition.x - width, startPosition2.y, startPosition2.z);
                }
                break;
            #endregion

            case Direction.Left:
                #region ���ɃX�N���[��
                // �w�i�����ɃX�N���[��
                pos1.x = image1.transform.localPosition.x - Time.deltaTime * samples  * ADD_SPEED;
                pos2.x = image2.transform.localPosition.x - Time.deltaTime * samples  * ADD_SPEED;

                image1.transform.localPosition = pos1;
                image2.transform.localPosition = pos2;

                // �w�i����ʊO�ɏo����Ĕz�u
                if (image1.transform.localPosition.x <= -width)
                {
                    image1.transform.localPosition = new Vector3(image2.transform.localPosition.x + width, startPosition1.y, startPosition1.z);
                }
                if (image2.transform.localPosition.x <= -width)
                {
                    image2.transform.localPosition = new Vector3(image1.transform.localPosition.x + width, startPosition2.y, startPosition2.z);
                }
                break;
                #endregion
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
        if (!isStop)
        {

            // �e�����ɃX�N���[��
            Scroll();
        }
    }
}
