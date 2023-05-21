using UnityEngine;

namespace Aureola.Accessories
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
