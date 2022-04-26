using System;
using System.Collections.Generic;
using System.Text;

namespace FOGO.Services
{
    public interface IStatusBarStyleManager
    {
        void SetColoredStatusBar(string hexColor);
        void SetWhiteStatusBar();
    }
}
