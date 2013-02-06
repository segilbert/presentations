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
using imcode.ObjectToObjectMapping.Domain;

namespace imcode.ObjectToObjectMapping.Data
{
    public class CxTrainRepository : IxRepository
    {
        public T FindById<T>(object id) 
        {
            object train = new CxTrain
            {
                Name = "Thomas",
                Number = (int)id,
                DefaultEngineer = new CxEngineer
                {
                    Id = 1,
                    FirstName = "Logan",
                    LastName = "Manner",
                    CallSign = "BigDaddy"
                }
            };

            return (T) train;
        }
    }
}
