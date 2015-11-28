using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICS.Acquisition;
using ICS.Models;
using ICS.Common;

namespace ICS.Air
{
    class Global
    {
        public static ADAM4017 ADAM4017Provider
        {
            get { return (ADAM4017) ClassFactory.GetProvider(equipmentCategory.ADAM4017, ComSetting); }
        }

        public static Models.Com.ComSettingModel _ComSetting;

        public static Models.Com.ComSettingModel ComSetting
        {
            get
            {
                if (_ComSetting == null)
                {
                    _ComSetting = new SettingHelper<Models.Com.ComSettingModel>().GetSetting();
                    _ComSetting.AnalogQuantityCom = "Com2";
                    
                }
                return _ComSetting;
            }
        }
    }
}
