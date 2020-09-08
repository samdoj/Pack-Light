using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Pack_Light
{
    interface iPackageParser
    {
        public static String directory;
        public abstract ArrayList GetDependencies(String filename);
        public abstract ArrayList GetFunctions();
        public abstract ArrayList GetConstants();
        public abstract StringBuilder CleanDependencies();
    }
}
