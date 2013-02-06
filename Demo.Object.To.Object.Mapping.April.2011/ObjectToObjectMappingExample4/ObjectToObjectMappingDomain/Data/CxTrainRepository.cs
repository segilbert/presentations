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
using System.Collections.Generic;
//
using System.Data;
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
                },
                IsAwake = true
            };

            return (T) train;
        }

        public IList<T> FindAll<T>()
        {
            var trains = 
                new List<CxTrain>()
                            {
                                new CxTrain{Id=2,IsAwake=true,Name="Charlie",Number=12,DefaultEngineer= new CxEngineer{Id=4,FirstName="Marc",LastName="Polo",CallSign="MarcoPolo"}},
                                new CxTrain{Id=4,IsAwake=true,Name="Mavis",Number=5,DefaultEngineer= new CxEngineer{Id=4,FirstName="Ken",LastName="Davis",CallSign="Davis"}},
                                new CxTrain{Id=6,IsAwake=false,Name="Gordon",Number=4,DefaultEngineer= new CxEngineer{Id=4,FirstName="Harvey",LastName="Danon",CallSign="Harv"}},
                                new CxTrain{Id=8,IsAwake=false,Name="Percy",Number=2,DefaultEngineer= new CxEngineer{Id=4,FirstName="Mercy",LastName="Krap",CallSign="Mercy"}}
                            };

            return (IList<T>)trains;
        }

        public IDataReader GetDataReader<T>()
        {
            throw new NotImplementedException();
        }
    }
}
