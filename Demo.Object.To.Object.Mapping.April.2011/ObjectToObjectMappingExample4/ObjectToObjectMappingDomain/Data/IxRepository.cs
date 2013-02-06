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
using System.Data;

namespace imcode.ObjectToObjectMapping.Data
{
    public interface IxRepository
    {
        T FindById<T>(object id);
        IList<T> FindAll<T>();
        IDataReader GetDataReader<T>();
    }
}
