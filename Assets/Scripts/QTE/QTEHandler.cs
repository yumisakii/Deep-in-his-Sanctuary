using UnityEngine;
using UnityEngine.UI;

public class QTEHandler : MonoBehaviour
{
    [SerializeField] private CombatRoomManager combatRoomManager = null;
    [SerializeField] private Canvas qteCanvas = null;
    [SerializeField] private RectTransform qteTargetRectTransform = null;
    [SerializeField] private RectTransform qteMarkRectTransform = null;
    [SerializeField] private Button qteButton = null;
    [SerializeField] private float markSpeed = 100f;

    private float newQTETargetPosition = 0f;
    private float qteBigTargetWidth = 40f;
    private float qteSmallTargetWidth = 10f;
    private const float MAX_QTE_TARGET_POSITION = 460f;

    private Vector2 qteMarkPosition = new Vector2();
    private const float MAX_QTE_MARK_POSITION = 490f;

    private bool isQTERunning = false;

    private void Awake()
    {
        qteCanvas.enabled = false;
    }

    private void Update()
    {
        if (isQTERunning)
        {
            qteMarkPosition.x += markSpeed * Time.deltaTime;
            qteMarkRectTransform.anchoredPosition = qteMarkPosition;

            if (qteMarkPosition.x >= MAX_QTE_MARK_POSITION)
                EndQTE();
        }
    }

    public void StartQTE()
    {
        qteCanvas.enabled = true;
        qteButton.interactable = true;

        newQTETargetPosition = UnityEngine.Random.Range(100, MAX_QTE_TARGET_POSITION);
        qteTargetRectTransform.anchoredPosition = new Vector2(newQTETargetPosition, 0);

        isQTERunning = true;
    }

    private void EndQTE()
    {
        isQTERunning = false;
        qteMarkRectTransform.anchoredPosition = new Vector2();
        qteMarkPosition.x = 0;

        qteButton.interactable = false;
        qteCanvas.enabled = false;
    }

    public void QTEPress()
    {
        float smallTarget = (qteSmallTargetWidth / 2);
        float bigTarget = (qteBigTargetWidth / 2);

        if (qteMarkPosition.x > newQTETargetPosition - smallTarget && qteMarkPosition.x < newQTETargetPosition + smallTarget) // If the mark is in the small targer position
            QTESuccess(2); // Perfect
        
        else if (qteMarkPosition.x > newQTETargetPosition - bigTarget && qteMarkPosition.x < newQTETargetPosition + bigTarget) // If the mark is in the big targer position
            QTESuccess(1); // Success

        else
            QTESuccess(0); // Fail
        
    }

    private void QTESuccess(int success)
    {
        EndQTE();
        combatRoomManager.QTESuccess(success);
    }

}
