#region license

/*
Copyright 2011 Sean Gilbert

Dual licensed under the MIT or GPL Version 2 licenses.

Unless required by applicable law or agreed to in writing, software 
distributed under the License is distributed on an "AS IS" BASIS, 
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
See the License for the specific language governing permissions and 
limitations under the License. 
*/

#endregion

//
using System;
//
using System.Data;
using imcode.ObjectToObjectMapping.Domain;
using imcode.ObjectToObjectMapping.ViewModels;
//
using Omu.ValueInjecter;

namespace imcode.ObjectToObjectMapping.Mappings
{
    public class IntToString : LoopValueInjection
    {
        protected override bool TypesMatch(Type sourceType, Type targetType)
        {
            return sourceType == typeof(int) && targetType == typeof(string);
        }

        protected override object SetValue(object sourcePropertyValue)
        {
            return Convert.ToString(sourcePropertyValue);
        }
    }

    public class StringToInt : LoopValueInjection
    {
        protected override bool TypesMatch(Type sourceType, Type targetType)
        {
            return sourceType == typeof(string) && targetType == typeof(int);
        }

        protected override object SetValue(object sourcePropertyValue)
        {
            return Convert.ToInt32(sourcePropertyValue);
        }
    }

    public class BooleanToString : LoopValueInjection
    {
        protected override bool TypesMatch(Type sourceType, Type targetType)
        {
            return sourceType == typeof(bool) && targetType == typeof(string);
        }

        protected override object SetValue(object sourcePropertyValue)
        {
            return Convert.ToBoolean(sourcePropertyValue) ? "Y" : "N";
        }
    }

    public class StringToBoolean : LoopValueInjection
    {
        protected override bool TypesMatch(Type sourceType, Type targetType)
        {
            return sourceType == typeof(string) && targetType == typeof(bool);
        }

        protected override object SetValue(object sourcePropertyValue)
        {
            return Convert.ToString(sourcePropertyValue).ToUpper().Equals("Y") ? true : false;
        }
    }

    public class FromEngineerToSimpleStringName : KnownTargetValueInjection<CxBrowseTrainsViewModel>
    {
        protected override void Inject(object source, ref CxBrowseTrainsViewModel target)
        {
            CxEngineer engineer = 
                (CxEngineer)source.GetProps()["DefaultEngineer"].GetValue(source);
            if (engineer != null )
                target.DefaultEngineerName = string.Format("{0}, {1}", 
                                                engineer.LastName, 
                                                engineer.FirstName);
        }
    }

    public class ReaderInjection : KnownSourceValueInjection<IDataReader>
    {
        protected override void Inject(IDataReader source, object target)
        {
            for ( var i = 0; i < source.FieldCount; i++)
            {
                var activeTarget = target.GetProps().GetByName(source.GetName(i), true);
                if (activeTarget == null) continue;

                var value = source.GetValue(i);
                if (value == DBNull.Value) continue;
                
                activeTarget.SetValue(target,value);
            }
        }
    }
    
}
