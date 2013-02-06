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

using System.Collections.Generic;
using imcode.ObjectToObjectMapping.Domain;

namespace imcode.ObjectToObjectMapping.ViewModels
{
    public class CxLineViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfSwitches { get; set; }
        public int LocationId { get; set; }
        public string LocationAddressLine1 { get; set; }
        public string LocationCity { get; set; }
        public string LocationCountry { get; set; }
        public string LocationPostalCode { get; set; }
        public string LocationLongitude { get; set; }
        public string LocationLatitude { get; set; }
    }

    public class CxLineViewModel2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfSwitches { get; set; }
        public CxLocationViewModel Location { get; set; }
        //public IEnumerable<CxLocationViewModel> Location { get; set; }
    }
}