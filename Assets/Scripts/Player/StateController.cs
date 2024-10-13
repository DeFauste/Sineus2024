using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StateController
{
    public bool IsBash = false; //стан
    public int Blinding = 0; // ослепление
    public int Distraction = 0; //Рассеяность
    public int IsFreezing = 0; //заморозка
    public int Shield = 0; //щит
    public int Dodge = 0; //уоврот
    public int Trick = 0; //Хитрость

    public void ClearNegativeState()
    {
        IsBash = false; //стан
        Blinding = 0; // ослепление
        Distraction = 0; //Рассеяность
        IsFreezing = 0; //заморозка
    }
}

