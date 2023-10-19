using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class UIDamage : MonoBehaviour
{
    private TextMeshProUGUI damageText;
    private float point;
    private Vector3 initPosition;

    void Awake()
    {
        damageText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        point = 0;
    }

    void Update()
    {
        point = Mathf.Lerp(point, 0.3f, 0.1f);

        transform.position = initPosition + Vector3.up * point;

        if (0.3f - point < 0.1f)
        {
            gameObject.SetActive(false);
        }
    }

    public void ShowDamage(float damage)
    {
        initPosition = transform.position;
        damageText.text = damage.ToString("N0");
    }
}
