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
    public interface IxControlList
    {
        string Description { get; set; }
        string DescriptionOverride { get; set; }
        string Code { get; set; }
    }
}
