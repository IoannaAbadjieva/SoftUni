namespace ChristmasPastryShop.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Helper
    {
        public static Dictionary<string,double> cocktailPriceMultyplier= new Dictionary<string, double>()
        {
            {"Large",1 },
            {"Middle",2.0/3.0 },
            {"Small",1.0/3.0 },
        };
    }
}
