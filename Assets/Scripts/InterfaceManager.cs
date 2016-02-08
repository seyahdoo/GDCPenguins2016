using UnityEngine;
using System.Collections;

public class InterfaceManager : MonoBehaviour {


    private InterfaceManager _im;
    public InterfaceManager Instance
    {

        get {

            if(_im == null)
            {
                _im = this;
            }

            return _im;
        }

    }


    public void MotherboardOn()
    {
        
    }

    public void CpuOn()
    {

    }

    public void PowerOn()
    {

    }

    public void PipeOn()
    {

    }

    public void UsbOn()
    {

    }

    public void ScreenOn()
    {

    }

    public void CablesOn()
    {

    }





}
