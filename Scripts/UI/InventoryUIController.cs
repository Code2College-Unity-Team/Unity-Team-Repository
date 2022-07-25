using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine.UIElements;
using UnityEngine;


namespace Assets.Scripts.UI {
public class InventoryUIController : MonoBehaviour
{
    public List<InventorySlot> InventoryItems = new List<InventorySlot>();

        private VisualElement m_Root;
        private VisualElement m_SlotContainer;

        private void Awake() {
            m_Root = GetComponent<UIDocument>().rootVisualElement;

            m_SlotContainer = m_Root.Q<VisualElement>("slot_container");

            for (int i = 0; i < 20; i++) {
                InventorySlot item = new InventorySlot();

                InventoryItems.Add(item);

                m_SlotContainer.Add(item);
            }
        }
    
    }
}