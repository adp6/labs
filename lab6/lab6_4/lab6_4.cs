using System;
using System.Collections;
using System.Collections.Generic;


namespace lab6_4 {
    public class MyFactory<T>  where T : new()
    {
        public static T FacrotyMethod()
        {
            return new T();
        }
    }
}
    