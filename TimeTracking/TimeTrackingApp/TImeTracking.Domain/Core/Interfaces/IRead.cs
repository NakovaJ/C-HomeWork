using System;
using System.Collections.Generic;
using System.Text;

namespace TImeTracking.Domain.Core.Interfaces
{
    interface IRead
    {
        int Pages { get; set; }
        int EnterPagesRead();

        void SelectTypeOfLiterature();
    }
}
