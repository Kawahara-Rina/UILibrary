using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class TapEffectManager : MonoBehaviour
{

    #region - �^�b�v�G�t�F�N�g��\������L�����o�X
    [Header("�^�b�v�G�t�F�N�g��\������L�����o�X")]
    #endregion
    [SerializeField] Canvas canvas;

    [Header("-�^�b�v�G�t�F�N�g-------------------------")]

    #region - �^�b�v�G�t�F�N�g�Ɏg�p����摜���i�[����z��
    [Header("�g�p����摜(�A�j���[�V������)")]
    [Tooltip("2�`5���H")]
    #endregion
    [SerializeField] public Sprite[] tapEffectSprites = new Sprite[5];

    #region - �^�b�v�G�t�F�N�g�̃A�j���[�V�����̑��x
    [Header("�A�j���[�V�����̑��x")]
    [Tooltip("0.1�`4.0�̒l�B4���x���A0.1������")]
    [Range( Common.MAX_SAMPLES, Common.MIN_SAMPLES)]
    #endregion
    [SerializeField] public float tapEffectSamples = 0.4f;


    [Header("-�����O�^�b�v�G�t�F�N�g-------------------")]
    
    #region - �����O�^�b�v�G�t�F�N�g�Ɏg�p����摜���i�[����z��
    [Header("�g�p����摜(�A�j���[�V������)")]
    [Tooltip("2�`5���H")]
    #endregion
    [SerializeField] public Sprite[] longTapEffectSprites = new Sprite[5];

    #region - �����O�^�b�v�G�t�F�N�g�̃A�j���[�V�����̑��x
    [Header("�A�j���[�V�����̑��x")]
    [Tooltip("0.1�`4.0�̒l�B4���x���A0.1������")]
    [Range(Common.MAX_SAMPLES, Common.MIN_SAMPLES)]
    #endregion
    [SerializeField] public float longTapEffectSamples = 1.0f;

    #region - �����O�^�b�v�G�t�F�N�g�̐������x
    [Header("�G�t�F�N�g�����̑��x")]
    [Tooltip("0.1�`4.0�̒l�B4���x���A0.1������")]
    [Range(Common.MAX_SAMPLES, Common.MIN_SAMPLES)]
    #endregion
    [SerializeField] public float generateSamples = 0.1f;

    // �p�b�P�[�W���̃v���t�@�u�擾�p
    private GameObject tapEffectPrefab;

    // �L�����o�X���̃��N�g�g�����X�t�H�[���擾�p
    private RectTransform canvasRect;
    // �|�C���^�[(�}�E�X)�̈ʒu
    private Vector2 mPos;

    // ���炩���߃I�u�W�F�N�g�𐶐����邽�߂̃��X�g
    private List<GameObject> tapObjList = new List<GameObject>();
    private List<GameObject> longTapObjList = new List<GameObject>();
    // ���X�g�̓Y�������w�肷�邽�߂̃J�E���g
    private int tapIndex;
    private int longTapIndex;

    // �����O�^�b�v�G�t�F�N�g�\���܂ł̃^�C�}�[
    private float showTimer;

    /// <summary>
    /// ���������� 
    /// </summary>
    private void Init()
    {
        // TODO �p�X�w��
        // �p�b�P�[�W���̃^�b�v�G�t�F�N�g�v���t�@�u���擾
        tapEffectPrefab =Resources.Load<GameObject>
            ("Prefabs/TapEffect");

        // �L�����o�X�̃��N�g�g�����X�t�H�[���擾
        canvasRect = canvas.GetComponent<RectTransform>();

        // �^�b�v�G�t�F�N�g�Ɏg�p����I�u�W�F�N�g�𐶐����A���X�g�ɓo�^
        for (int i = 0; i < Common.GENERATE_COUNT; i++)
        {
            // �����O�^�b�v�G�t�F�N�g�p
            var tmpLong = Instantiate(tapEffectPrefab);
            tmpLong.gameObject.transform.SetParent(canvas.transform, false);
            tmpLong.GetComponent<Image>().sprite = longTapEffectSprites[0];
            longTapObjList.Add(tmpLong);

            // �^�b�v�G�t�F�N�g�p
            var tmp = Instantiate(tapEffectPrefab);
            tmp.gameObject.transform.SetParent(canvas.transform, false);
            tmp.GetComponent<Image>().sprite = tapEffectSprites[0];
            tapObjList.Add(tmp);
        }
    }

    /// <summary>
    /// �^�b�v�E�����O�^�b�v�G�t�F�N�g�̕\�����s���֐�
    /// </summary>
    /// <param name="_list">�^�b�v�E�����O�^�b�v�p�̃I�u�W�F�N�g���i�[����Ă��郊�X�g</param>
    /// <param name="_index">���X�g���̓Y�������w�肷��p</param>
    /// <param name="_sprites">�^�b�v�E�����O�^�b�v�Ɏg�p����X�v���C�g���i�[����Ă���z��</param>
    /// <param name="_samples">�A�j���[�V�����̑��x</param>
    private void ShowEffect(List<GameObject> _list , int _index , Sprite[] _sprites, float _samples)
    {
        // �^�b�v�����ꏊ���擾
        // �L�����o�X�̃��N�g�g�����X�t�H�[�����ɂ���}�E�X�̈ʒu�����[�J�����W�ɕϊ�
        RectTransformUtility.ScreenPointToLocalPointInRectangle
            (canvasRect,
            Input.mousePosition,
            canvas.worldCamera,
            out mPos);

        // ���X�g�̒��̃I�u�W�F�N�g��\��
        _list[_index].gameObject.transform.localPosition = new Vector2(mPos.x, mPos.y);
        _list[_index].gameObject.SetActive(true);

        // EffectAnimation�R���[�`�����J�n
        StartCoroutine(_list[_index].GetComponent<TapEffect>().EffectAnimation(
            _sprites,
            _samples * Common.MIN_SAMPLES));
    }

    /// <summary>
    // �^�b�v�G�t�F�N�g�̕\�����s���֐�
    /// </summary>
    private void TapEffect()
    {
        // �^�b�v�G�t�F�N�g��\��
        ShowEffect(tapObjList, tapIndex, tapEffectSprites, tapEffectSamples);

        // �Y�������J�E���g
        if (tapIndex < Common.GENERATE_COUNT - 1)
        {
            tapIndex++;
        }
        else
        {
            tapIndex = 0;
        }
    }
    
    /// <summary>
    // �����O�^�b�v�G�t�F�N�g�̕\�����s���֐�
    /// </summary>
    private void LongTapEffect()
    {
        showTimer += Time.deltaTime;

        // ���̐����܂ł̃^�C�}�[���o�߂�����
        if (showTimer >= generateSamples * 0.1f)
        {
            // �^�b�v�������W�Ƀ����O�^�b�v�G�t�F�N�g��\��
            ShowEffect(longTapObjList, longTapIndex, longTapEffectSprites, longTapEffectSamples);

            // �Y�������J�E���g
            if (longTapIndex < Common.GENERATE_COUNT - 1)
            {
                longTapIndex++;
            }
            else
            {
                longTapIndex = 0;
            }

            showTimer = 0;

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
        if (Input.GetMouseButtonDown(0))
        {
            // �^�b�v�������W�Ƀ^�b�v�G�t�F�N�g��\��
            TapEffect();
        }
        if (Input.GetMouseButton(0))
        {
            // �����O�^�b�v�G�t�F�N�g��\��
            LongTapEffect();
        }
    }
}

