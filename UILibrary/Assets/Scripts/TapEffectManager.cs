using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TapEffectManager : MonoBehaviour
{
    #region - �g�p����摜���i�[����z��
    [Header("�g�p����摜(�A�j���[�V������)")]
    [Tooltip("2�`5���H")]
    #endregion
    [SerializeField] public Sprite[] sprites;

    #region - �A�j���[�V�����̑��x
    [Header("�A�j���[�V�����̑��x")]
    [Tooltip("0.1�`4.0�̒l�B4���x���A0.1������")]
    [Range( Common.MAX_SAMPLES, Common.MIN_SAMPLES)]
    #endregion
    [SerializeField] public float samples;

    #region - �^�b�v�G�t�F�N�g�v���t�@�u
    [Header("�v���t�@�u �hTapEffect�h���i�[")]
    [Tooltip("Assets/Resources/Prefabs/TapEffect")]
    #endregion
    [SerializeField] GameObject tapEffectPrefab;

    #region - �^�b�v�G�t�F�N�g��\������L�����o�X
    [Header("�^�b�v�G�t�F�N�g��\������L�����o�X")]
    //[Tooltip("Assets/Resources/Prefabs/TapEffect")]
    #endregion
    // �\������L�����o�X
    [SerializeField] Canvas canvas;

    // �L�����o�X���̃��N�g�g�����X�t�H�[���擾�p
    private RectTransform canvasRect;
    // �|�C���^�[(�}�E�X)�̈ʒu
    private Vector2 mPos;

    // ���炩���߃I�u�W�F�N�g�𐶐����邽�߂̃��X�g
    private List<GameObject> objList = new List<GameObject>();
    // ���X�g�̓Y�������w�肷�邽�߂̃J�E���g
    private int index;

    /// <summary>
    /// ���������� 
    /// </summary>
    private void Init()
    {
        // �L�����o�X�̃��N�g�g�����X�t�H�[���擾
        canvasRect = canvas.GetComponent<RectTransform>();

        // �v���t�@�u�����X�g�ɓo�^
        for (int i = 0; i < Common.GENERATE_COUNT; i++)
        {
            var tmp = Instantiate(tapEffectPrefab);
            tmp.gameObject.transform.SetParent(canvas.transform, false);

            objList.Add(tmp);
        }
    }

    /// <summary>
    // �^�b�v�G�t�F�N�g�̕\�����s���֐�
    /// </summary>
    private void ShowTapEffect()
    {
        // �^�b�v�����ꏊ���擾
        // �L�����o�X�̃��N�g�g�����X�t�H�[�����ɂ���}�E�X�̈ʒu�����[�J�����W�ɕϊ�
        RectTransformUtility.ScreenPointToLocalPointInRectangle
            (canvasRect,
            Input.mousePosition,
            canvas.worldCamera,
            out mPos);

        // ���X�g�̒��̃I�u�W�F�N�g��\��
        objList[index].gameObject.transform.localPosition = new Vector2(mPos.x,mPos.y);
        objList[index].gameObject.SetActive(true);

        // EffectAnimation�R���[�`�����J�n
        StartCoroutine(objList[index].GetComponent<TapEffect>().EffectAnimation(
            sprites,
            samples * Common.MIN_SAMPLES));

        // �Y�������J�E���g
        if (index < Common.GENERATE_COUNT-1)
        {
            index++;
        }
        else
        {
            index = 0;
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
            ShowTapEffect();
        }

        if (Input.GetKey(KeyCode.A))
        {
            SceneManager.LoadScene("New Scene");
        }
    }
}
