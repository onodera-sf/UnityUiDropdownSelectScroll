using UnityEngine;
using UnityEngine.UI;    // 追加

public class DropdownScroll : MonoBehaviour
{
  public void Start()
  {
    // スクロールの計算に必要な各コンポーネントを取得
    var dropdown = GetComponentInParent<Dropdown>();
    var scrollRect = gameObject.GetComponent<ScrollRect>();
    var viewport = transform.Find("Viewport").GetComponent<RectTransform>();
    var contentArea = transform.Find("Viewport/Content").GetComponent<RectTransform>();
    var contentItem = transform.Find("Viewport/Content/Item").GetComponent<RectTransform>();

    // 選択しているアイテムの位置や表示領域をもとに選択アイテムまでスクロールすべき量を計算する
    var areaHeight = contentArea.rect.height - viewport.rect.height;
    var cellHeight = contentItem.rect.height;
    var scrollRatio = (cellHeight * dropdown.value) / areaHeight;
    scrollRect.verticalNormalizedPosition = 1.0f - Mathf.Clamp(scrollRatio, 0.0f, 1.0f);
  }
}
