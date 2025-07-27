using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public int coast;
    public ITEM_STATE itemState;

    public enum ITEM_STATE  {ГОВНИЩЕ, СОЙДЁТ, НОРМУЛЬ, ТОП}
}