using UnityEngine;

namespace Aureola.Interface
{
    public class WebsiteButton : ClickableButton
    {
        [SerializeField] private string _url;

        public void OnClick()
        {
            Application.OpenURL(_url);
        }
    }
}
