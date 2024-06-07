using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SeatManager : MonoBehaviour
{
    public InputField inputField;
    public ToggleGroup toggleGroup;
    public ScrollView[] scrollViews; // �����Ѿ�����˳����Inspector�и�ֵ
    public GameObject seatContentPrefab; // ��λ���ݵ�Ԥ����
    private void Start()
    {
        // ����ÿ����5����λ����10����λ
        int rows = 10;
        int seatsPerRow = 5;
        // ��ʼ��Toggle��ScrollView����
        for (int i = 0; i < rows; i++)
        {
            Toggle toggle = CreateToggle(i); // ����CreateToggle�᷵��һ��Toggleʵ������ӵ�UI��
            toggle.onValueChanged.AddListener(delegate { OnToggleValueChanged(toggle); });
            ScrollRect scrollRect = scrollViews[i].GetComponent<ScrollRect>();
            GameObject content = new GameObject("Content" + i);
            RectTransform contentTransform = content.AddComponent<RectTransform>();
            contentTransform.SetParent(scrollViews[i].transform, false);

            for (int j = 0; j < seatsPerRow; j++)
            {
                GameObject seat = Instantiate(seatContentPrefab, contentTransform);
                // ������λ��ţ�Text���������������...
                // ...
            }
            // ����ScrollView��Content��...
            // ...
        }
        // ����InputField��onEndEdit�¼�
        inputField.onEndEdit.AddListener(OnInputFieldEndEdit);
    }
    private void OnInputFieldEndEdit(string value)
    {
        if (int.TryParse(value, out int seatNumber))
        {
            int rowIndex = seatNumber / seatsPerRow; // ������λ��������
            int seatIndexInRow = seatNumber % seatsPerRow; // ������λ�������ŵ�����

            // ����Toggle�ǰ���˳�����еģ�����ֱ��ͨ�������ҵ���Ӧ��Toggle
            Toggle toggle = toggles[rowIndex]; // ������һ��toggles���鱣�������е�Toggle
            toggle.isOn = true; // ѡ�ж�Ӧ��Toggle

            // ����OnToggleValueChanged��ģ��Toggle�仯�¼�
            OnToggleValueChanged(toggle);
            // ��������Ӧ����λ����Ҫʵ��ScrollToSeat������
            ScrollToSeat(rowIndex, seatIndexInRow);
        }
    }
    private void OnToggleValueChanged(Toggle toggle)
    {
        // ���ﴦ��Toggle�仯ʱ���߼�������򿪶�Ӧ��ScrollView
        int index = System.Array.IndexOf(toggleGroup.ActiveToggles(), toggle);
        if (index != -1)
        {
            ScrollRect scrollRect = scrollViews[index].GetComponent<ScrollRect>();
            // ... ��ScrollView���߼� ...
        }
    }
    private void ScrollToSeat(int rowIndex, int seatIndexInRow)
    {
        // ����ʵ�ֹ������ض���λ���߼�
        // ��Ҫ����seatIndexInRow�ҵ���Ӧ����λGameObject����������λ�ã�Ȼ�����ScrollView����λ��
    }
    // ... �����������߼� ...
}