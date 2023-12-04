using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayInv : MonoBehaviour
{
   // public InventorySlots inventory;
   // private int xSpace = 150;
   // private int xStart = -300;
   // private int columns = 5;
   // Dictionary<Slots, GameObject> itemDisplayed = new Dictionary<Slots, GameObject>();
   // // Start is called before the first frame update
   // void Start()
   // {
   //     CreateDisplay();
   // }
   //
   // // Update is called once per frame
   // void Update()
   // {
   //     UpdateDisplay();
   // }
   // public void CreateDisplay()
   // {
   //     for (int i = 0; i < inventory.Container.Count; i++)
   //     {
   //         //Debug.Log("displayed");
   //         var obj = Instantiate(inventory.Container[i].gun.prefab, Vector3.zero, Quaternion.identity, transform);
   //         obj.GetComponent<RectTransform>().localPosition = GetPos(i);
   //         obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
   //         itemDisplayed.Add(inventory.Container[i], obj);
   //     }
   // }
   // public Vector3 GetPos(int i)
   // {
   //     return new Vector3((xStart + xSpace * (i % columns)), (-0 * (i/columns)), 0f);
   // }
   // public void UpdateDisplay()
   // {
   //     for (int i = 0; i < inventory.Container.Count; i++)
   //     {
   //         if (itemDisplayed.ContainsKey(inventory.Container[i]))
   //         {
   //             itemDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
   //         }
   //         else
   //         {
   //             var obj = Instantiate(inventory.Container[i].gun.prefab, Vector3.zero, Quaternion.identity, transform);
   //             obj.GetComponent<RectTransform>().localPosition = GetPos(i);
   //             obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
   //             itemDisplayed.Add(inventory.Container[i], obj);
   //         }
   //     }
   // }
}
