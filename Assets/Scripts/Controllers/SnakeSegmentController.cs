using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SnakeSegmentController : MonoBehaviour
{

    [SerializeField] private Color segmentColor = ColorUtils.FromHex(0x99FF99FF);
    [SerializeField] private Color headColor = ColorUtils.FromHex(0xFF9999FF);

    private SpriteRenderer spriteRenderer;
    private bool isHead;

    public bool IsHead
    {
        get { return isHead; }
        set
        {
            isHead = value;
            UpdateView();
        }
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void UpdateView()
    {
        spriteRenderer.color = IsHead ? headColor : segmentColor;
    }

}