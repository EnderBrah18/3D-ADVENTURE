using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Itens
{
    public class ItemLayout : MonoBehaviour
    {
        private ItemSetup _currSetup;


        public Image uiIcon;
        public TextMeshProUGUI uiValue;

        public void Load(ItemSetup setup)
        {
            _currSetup = setup;
            UpdateUI();
        }

        private void UpdateUI()
        {
            uiIcon.sprite = _currSetup.icon;
        }

        private void Update()
        {
            uiValue.text = _currSetup.soInt.value.ToString();
        }

    }



}