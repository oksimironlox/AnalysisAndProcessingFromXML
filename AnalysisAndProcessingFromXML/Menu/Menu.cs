﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisAndProcessingFromXML.Menu
{
    internal interface Menu
    {
        void DrawMenu(List<MenuItem> menu);
        void MenuSelectNext(List<MenuItem> menu);
        void MenuSelectPrev(List<MenuItem> menu);
        void Execute(string commandId);
        void Menu();

    }
}
