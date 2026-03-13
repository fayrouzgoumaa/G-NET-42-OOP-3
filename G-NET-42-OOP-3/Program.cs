using System.ComponentModel;
using System.Security.AccessControl;

namespace G_NET_42_OOP_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region part1
            //Q1 
            //    a)Composition
            //    b)Association
            //    c)Inheritance
            //    d)Aggregation
            //    e)Dependency
            //Q2
            //    a)Yes, the child class can access it even if it is in a different assembly.
            //    It cannot be accessed through an object instance from outside.
            //    b)protected internal >>Accessible from same assembly OR derived classes in other assemblies
            //    private protected >>Accessible only by derived classes AND inside the same assembly
            //    c)When applied to a class It prevents inheritance.
            //    When applied to a method It prevents further overriding.
            //    d)Yes, you can create objects from a sealed class.
            //    sealed only prevents inheritance, not instantiation
            #endregion
        }
    }
}
