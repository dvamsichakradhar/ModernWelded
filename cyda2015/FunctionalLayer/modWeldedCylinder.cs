
using IFLBaseDataLayer;
using IFLCommonLayer;

namespace Welded.FunctionalLayer
{
    public static class modWeldedCylinder
    {
        #region variables
       
        private  static clsWeldedCylinderFunctionalClass _oClsWeldedCylinderFunctionalClass;

        private static IFLConnectionClass _oMonarchConnectionObject;

        #endregion

        #region Properties

        public static clsWeldedCylinderFunctionalClass ObjClsWeldedCylinderFunctionalClass 
        { 
            get
            {
                return _oClsWeldedCylinderFunctionalClass;
            }
            set
            {
                _oClsWeldedCylinderFunctionalClass=value;
            }
 
        }


        public static IFLConnectionClass MonarchConnectionObject
        {
            get
            {
                return _oMonarchConnectionObject;
            }
            set
            {
                _oMonarchConnectionObject=value;
            }
        }

        #endregion
    }
}
