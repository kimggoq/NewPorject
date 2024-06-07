using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SeatManager : MonoBehaviour
{
    public InputField inputField;
    public ToggleGroup toggleGroup;
    public ScrollView[] scrollViews; // 假设已经按照顺序在Inspector中赋值
    public GameObject seatContentPrefab; // 座位内容的预制体
    private void Start()
    {
        // 假设每排有5个座位，有10排座位
        int rows = 10;
        int seatsPerRow = 5;
        // 初始化Toggle和ScrollView内容
        for (int i = 0; i < rows; i++)
        {
            Toggle toggle = CreateToggle(i); // 假设CreateToggle会返回一个Toggle实例并添加到UI中
            toggle.onValueChanged.AddListener(delegate { OnToggleValueChanged(toggle); });
            ScrollRect scrollRect = scrollViews[i].GetComponent<ScrollRect>();
            GameObject content = new GameObject("Content" + i);
            RectTransform contentTransform = content.AddComponent<RectTransform>();
            contentTransform.SetParent(scrollViews[i].transform, false);

            for (int j = 0; j < seatsPerRow; j++)
            {
                GameObject seat = Instantiate(seatContentPrefab, contentTransform);
                // 设置座位序号（Text组件）和其他属性...
                // ...
            }
            // 设置ScrollView的Content等...
            // ...
        }
        // 监听InputField的onEndEdit事件
        inputField.onEndEdit.AddListener(OnInputFieldEndEdit);
    }
    private void OnInputFieldEndEdit(string value)
    {
        if (int.TryParse(value, out int seatNumber))
        {
            int rowIndex = seatNumber / seatsPerRow; // 计算座位所在排数
            int seatIndexInRow = seatNumber % seatsPerRow; // 计算座位在所在排的索引

            // 假设Toggle是按照顺序排列的，可以直接通过索引找到对应的Toggle
            Toggle toggle = toggles[rowIndex]; // 假设有一个toggles数组保存了所有的Toggle
            toggle.isOn = true; // 选中对应的Toggle

            // 调用OnToggleValueChanged来模拟Toggle变化事件
            OnToggleValueChanged(toggle);
            // 滚动到对应的座位（需要实现ScrollToSeat方法）
            ScrollToSeat(rowIndex, seatIndexInRow);
        }
    }
    private void OnToggleValueChanged(Toggle toggle)
    {
        // 这里处理Toggle变化时的逻辑，比如打开对应的ScrollView
        int index = System.Array.IndexOf(toggleGroup.ActiveToggles(), toggle);
        if (index != -1)
        {
            ScrollRect scrollRect = scrollViews[index].GetComponent<ScrollRect>();
            // ... 打开ScrollView的逻辑 ...
        }
    }
    private void ScrollToSeat(int rowIndex, int seatIndexInRow)
    {
        // 这里实现滚动到特定座位的逻辑
        // 需要根据seatIndexInRow找到对应的座位GameObject，并计算其位置，然后滚动ScrollView到该位置
    }
    // ... 其他方法和逻辑 ...
}