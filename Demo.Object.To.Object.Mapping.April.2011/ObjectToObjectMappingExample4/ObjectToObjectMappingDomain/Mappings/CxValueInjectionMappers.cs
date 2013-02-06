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
using System.Collections.Generic;
//
using imcode.ObjectToObjectMapping.Domain;
using imcode.ObjectToObjectMapping.ViewModels;
//
using Omu.ValueInjecter;

namespace imcode.ObjectToObjectMapping.Mappings
{
     public static class CxLineViewModelMapper
     {
         public static IEnumerable<CxLineViewModel2> Map(IList<CxLine> pxLines)
         {
             foreach (CxLine pxLine in pxLines)
             {
                 CxLineViewModel2 vm = new CxLineViewModel2();
                 vm.InjectFrom(pxLine);
                 vm.Location = (CxLocationViewModel)new CxLocationViewModel().InjectFrom(pxLine.Location);
                 yield return vm;
             }
         }
     }
}
