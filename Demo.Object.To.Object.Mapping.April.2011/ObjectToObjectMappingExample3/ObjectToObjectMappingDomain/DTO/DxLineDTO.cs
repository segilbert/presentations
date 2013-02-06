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

namespace imcode.ObjectToObjectMapping.DTO
{
    public class DxLineDTO : IxControlList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfSwitches { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ( {1} )",
                        Name,
                        NumberOfSwitches);
        }

        #region Implementation of IxControlList

        public string Description
        {
            get { return ToString(); }
            set { }
        }

        public string DescriptionOverride
        {
            get { return Description; }
            set { }
        }

        public string Code
        {
            get { return Id.ToString(); }
            set { Id = int.Parse(value); }
        }

        #endregion
    }
}
