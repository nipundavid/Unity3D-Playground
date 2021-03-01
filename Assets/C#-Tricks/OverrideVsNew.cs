
using UnityEngine;
public  class Base
{
    public virtual void Printhello()
    {
        Debug.Log("Base says - Hello");
    }

    /// <summary>
    /// new is used to supress this
    /// </summary>
    public void PrintWorld()
    {
        Debug.Log("Hell");
    }
 
}

public class Derived : Base
{

    public override void Printhello()
    {
        Debug.Log("Derived Says Hello");
    }

    /// <summary>
    /// new keyword
    /// </summary>
    public new void PrintWorld()
    {
        Debug.Log("World");
    }

}

public class OverrideVsNew : MonoBehaviour
{
    private void Start()
    {
        Base baseObj = new Base();
        baseObj.Printhello();
        baseObj.PrintWorld();

        Derived deriObj = new Derived();
        deriObj.Printhello();
        deriObj.PrintWorld();

        Base obj = new Derived();
        obj.Printhello();
        obj.PrintWorld();
    }
}
